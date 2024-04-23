using Application.Contracts.Product.DTOs;
using Application.Enums;
using Application.Exceptions;
using Application.Repositories;
using Application.Services.Interfaces;
using Application.Utils;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Application.Services.Implementations;

public class ProductService(IUnitOfWork unitOfWork, IMapper mapper, IFileStorageService fileStorageService)
    : IProductService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly IFileStorageService _fileStorageService = fileStorageService;

    public async Task<GetProduct> GetProduct(Guid productId)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(productId);
        if (product == null)
        {
            throw new NotFoundException(nameof(Product), productId);
        }

        return _mapper.Map<GetProduct>(product)!;
    }

    public async Task<GetProduct> CreateProduct(CreateProduct createProduct, Guid userId)
    {
        var product = _mapper.Map<Product>(createProduct)!;

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
                InventoryId = variation.ProductInventory.Id
            });
        }

        await _unitOfWork.Products.AddAsync(product);
        await _unitOfWork.Transactions.AddAsync(transaction);

        await SaveImages(product.Images.Select(x => x.Url).ToList(), createProduct.Images);

        await _unitOfWork.CommitAsync();
        return _mapper.Map<GetProduct>(product)!;
    }

    public async Task<GetProduct> UpdateProduct(UpdateProduct updateProduct, Guid productId, Guid userId)
    {
        var product = await _unitOfWork.Products.GetByIdAsync(productId);

        if (product == null)
        {
            throw new NotFoundException(nameof(Product), productId);
        }

        var oldProductImages = product.Images.ToList();

        product = _mapper.Map(updateProduct, product)!;

        var transaction = CreateTransaction(userId, TransactionTypes.Update);

        foreach (var variation in updateProduct.Variations)
        {
            var inventory = await _unitOfWork.Inventories.GetByVariationIdAsync((Guid)variation.Id!);
            if (inventory == null)
            {
                // Add product variation
                inventory = new ProductInventory(updateProduct.Variations.First(x => x.Id == variation.Id).Stock);
                product.Variations.First(x => x.Id == variation.Id).ProductInventory = inventory;
                product.Variations.First(x => x.Id == variation.Id).ProductInventoryId = inventory.Id;
                await _unitOfWork.Variations.AddAsync(product.Variations.First(x => x.Id == variation.Id));
                await _unitOfWork.Inventories.AddAsync(inventory);
                transaction.TransactionDetails.Add(new TransactionDetail
                {
                    AmountAffected = inventory.Quantity,
                    InventoryId = inventory.Id
                });
            }
            else
            {
                product.Variations.First(x => x.Id == variation.Id).ProductInventory = inventory;
                product.Variations.First(x => x.Id == variation.Id).ProductInventoryId = inventory.Id;
                if (variation.Stock != inventory.Quantity)
                {
                    transaction.TransactionDetails.Add(new TransactionDetail
                    {
                        AmountAffected = variation.Stock - inventory.Quantity,
                        InventoryId = inventory.Id
                    });
                }
            }
        }
        await _unitOfWork.Products.UpdateAsync(product);

        await _unitOfWork.Transactions.AddAsync(transaction);

        await DeleteImages(oldProductImages.Select(x => x.Url));

        await _unitOfWork.ProductImages.DeleteRangeAsync(oldProductImages);

        await SaveImages(product.Images.Select(x => x.Url).ToList(), updateProduct.Images);

        await _unitOfWork.ProductImages.AddRangeAsync(product.Images);

        await _unitOfWork.CommitAsync();
        return _mapper.Map<GetProduct>(product)!;
    }

    public async Task<(List<GetProductSimpleDto>, double)> FilterProducts(ProductFilterDto filterDto)
    {
        var (paginatedProducts, totalRecords) = await _unitOfWork.Products.GetWithFiltersAsync(filterDto);
        var getProductSimple = _mapper.Map<List<GetProductSimpleDto>>(paginatedProducts) ?? [];
        return (getProductSimple, totalRecords);
    }

    private Transaction CreateTransaction(Guid userId, TransactionTypes transactionType)
    {
        var localTime = TimeZoneConverter.ConvertFromUtc(DateTime.UtcNow, "SA Pacific Standard Time");
        var transactionTypeId = transactionType.ToGuid();

        return new Transaction(localTime, transactionTypeId)
        {
            UserId = userId
        };
    }

    private async Task DeleteImages(IEnumerable<string> imagesPaths)
    {
        foreach (var path in imagesPaths)
        {
            await _fileStorageService.DeleteFile(path);
        }
    }

    private async Task SaveImages(IReadOnlyList<string> imagesPaths, IFormFileCollection images)
    {
        for (var i = 0; i < images.Count; i++)
        {
            await _fileStorageService.SaveFile(imagesPaths[i], images[i].OpenReadStream());
        }
    }
}