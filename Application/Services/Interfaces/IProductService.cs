using Application.Contracts.Product.DTOs;
using Domain.Entities;

namespace Application.Services.Interfaces;

public interface IProductService
{
    public Task<GetProduct> GetProduct(Guid productId);
    public Task<GetProduct> CreateProduct(CreateProduct createProduct, Guid userId);
    public Task<GetProduct> UpdateProduct(UpdateProduct updateProduct, Guid productId, Guid userId);
    public Task<(List<GetProductSimpleDto>, double)> FilterProducts(ProductFilterDto filterDto);
}