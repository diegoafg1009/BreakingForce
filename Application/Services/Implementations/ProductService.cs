using Application.Contracts.Product.DTOs;
using Application.Enums;
using Application.Repositories;
using Application.Services.Interfaces;
using Application.Utils;
using AutoMapper;
using Domain.Entities;

namespace Application.Services.Implementations;

public class ProductService(IUnitOfWork unitOfWork, IMapper mapper, IFileStorageService fileStorageService) : IProductService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly IFileStorageService _fileStorageService = fileStorageService;

    public async Task<GetProductDto> CreateProduct(CreateProductDto createProductDto, Guid userId)
    {
        var product = _mapper.Map<Product>(createProductDto)!;

        var localTime = TimeZoneConverter.ConvertFromUtc(DateTime.UtcNow, "SA Pacific Standard Time");

        var transactionTypeId = TransactionTypes.Creation.ToGuid();

        var transaction = new Transaction(localTime, transactionTypeId)
        {
            UserId = userId
        };

        foreach (var variation in product.Variations)
        {
            transaction.TransactionDetails.Add(new TransactionDetail
            {
                AmountAffected = variation.ProductInventory.Quantity,
                Inventory = variation.ProductInventory
            });
        }

        await _unitOfWork.Products.AddAsync(product);
        await _unitOfWork.Transactions.AddAsync(transaction);

        foreach (var (image, index) in createProductDto.Images.Select((value, index) => (value, index)))
        {
            await _fileStorageService.SaveFile(product.Images[index].Url, image.OpenReadStream());
        }

        await _unitOfWork.CommitAsync();
        return _mapper.Map<GetProductDto>(product)!;
    }

    public async Task<List<GetProductSimpleDto>> FilterProducts(ProductFilterDto filterDto)
    {
        var products = await _unitOfWork.Products.GetWithFiltersAsync(filterDto);
        return _mapper.Map<List<GetProductSimpleDto>>(products) ?? [];
    }
}