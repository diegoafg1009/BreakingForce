using Application.Contracts.Customer.DTOs;
using Application.Contracts.RegisterConfirmation.DTOs;

namespace Application.Services.Interfaces;

public interface ICustomerService
{
    Task<CustomerToken> Login(LoginCustomer model);
    Task Register(RegisterCustomer model);
    Task<CustomerToken> RegisterConfirmation(RegisterConfirmationRequest model);
}