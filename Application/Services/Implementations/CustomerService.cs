using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Contracts.Customer.DTOs;
using Application.Contracts.RegisterConfirmation.DTOs;
using Application.Exceptions;
using Application.Repositories;
using Application.Services.Interfaces;
using Application.Utils;
using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services.Implementations;

public class CustomerService(
    IUnitOfWork unitOfWork,
    IMapper mapper,
    IConfiguration configuration,
    IValidationService validationService,
    IEmailService emailService) : ICustomerService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly IValidationService _validationService = validationService;
    private readonly IConfiguration _configuration = configuration;
    private readonly IEmailService _emailService = emailService;
    private const int LockoutThreshold = 5;
    private const int LockoutDuration = 10;

    public async Task<CustomerToken> Login(LoginCustomer model)
    {
        _validationService.EnsureValid(model);

        var customer = await _unitOfWork.Customers.GetByEmailAsync(model.Email);

        if (customer is null)
        {
            throw new UnauthorizedException("Credentials are invalid");
        }

        var customerRegisterConfirmation =
            await _unitOfWork.CustomerRegisterConfirmationsRepository.GetByCustomerIdAsync(customer.Id);

        if (customerRegisterConfirmation is not null)
        {
            throw new ForbiddenException("Account is not confirmed yet");
        }

        var lockoutInfo = await _unitOfWork.CustomerLockoutInfos.GetByCustomerIdAsync(customer.Id) ??
                          new CustomerLockoutInfo { CustomerId = customer.Id };

        if (lockoutInfo.LockoutEnd.HasValue && lockoutInfo.LockoutEnd.Value > DateTime.Now)
        {
            throw new ForbiddenException("Account is locked");
        }

        if (_unitOfWork.Customers.VerifyPassword(customer, model.Password))
        {
            lockoutInfo.AccessFailedCount = 0;
            lockoutInfo.LockoutEnd = null;

            await _unitOfWork.CustomerLockoutInfos.AddOrUpdateAsync(lockoutInfo);
        }
        else
        {
            lockoutInfo.AccessFailedCount++;
            if (lockoutInfo.AccessFailedCount >= LockoutThreshold)
            {
                lockoutInfo.LockoutEnd = DateTime.Now.AddMinutes(LockoutDuration);
            }

            await _unitOfWork.CustomerLockoutInfos.AddOrUpdateAsync(lockoutInfo);

            await _unitOfWork.CommitAsync();

            throw new UnauthorizedException("Credentials are invalid");
        }

        var customerToken = GenerateToken(customer);

        return customerToken;
    }

    public async Task Register(RegisterCustomer model)
    {
        _validationService.EnsureValid(model);

        var customer = await _unitOfWork.Customers.GetByEmailAsync(model.Email);

        var customerRegisterConfirmation =
            await _unitOfWork.CustomerRegisterConfirmationsRepository.GetByCustomerEmailAsync(model.Email);

        if (customer is not null)
        {
            if (customerRegisterConfirmation is null)
            {
                throw new ConflictException("Customer already exists");
            }
            else
            {
                await _unitOfWork.CustomerRegisterConfirmationsRepository.DeleteAsync(customerRegisterConfirmation.Id);
            }

        }
        else
        {
            customer = _mapper.Map<Customer>(model)!;
            customer = await _unitOfWork.Customers.AddAsync(customer);
        }

        var registerConfirmation = new CustomerRegisterConfirmation
        {
            CustomerId = customer.Id,
            Token = Guid.NewGuid().ToString(),
            ExpirationDate = DateTime.Now.AddDays(1)
        };

        await _unitOfWork.CustomerRegisterConfirmationsRepository.AddAsync(registerConfirmation);

        await _emailService.SendEmailAsync(customer.Email, "Confirm your account",
            $"Please confirm your account with the code: {registerConfirmation.Token}", true);
        await _unitOfWork.CommitAsync();
    }

    public async Task<CustomerToken> RegisterConfirmation(RegisterConfirmationRequest model)
    {
        var registerConfirmation = await _unitOfWork.CustomerRegisterConfirmationsRepository.GetByToken(model.Token);

        if (registerConfirmation is null)
        {
            throw new AppException("Invalid token");
        }

        if (registerConfirmation.ExpirationDate < DateTime.Now)
        {
            throw new AppException("Token expired");
        }

        await _unitOfWork.CustomerRegisterConfirmationsRepository.DeleteAsync(registerConfirmation.Id);

        var customer = await _unitOfWork.Customers.GetByIdAsync(registerConfirmation.CustomerId);

        var customerToken = GenerateToken(customer!);

        await _unitOfWork.CommitAsync();

        return customerToken;
    }

    private CustomerToken GenerateToken(Customer customer)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, customer.Id.ToString()),
            new(ClaimTypes.Email, customer.Email),
            new(ClaimTypes.Name, $"{customer.Name} {customer.Surname}"),
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:StoreSecretKey"]!));

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:StoreAudience"],
            claims: claims,
            expires: DateTime.Now.AddYears(1),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
        );

        return new CustomerToken(new JwtSecurityTokenHandler().WriteToken(token));
    }
}