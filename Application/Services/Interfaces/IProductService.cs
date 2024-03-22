using Application.Contracts.Product.DTOs;
using Domain.Entities;

namespace Application.Services.Interfaces;

public interface IProductService
{
    public Task<GetProductDto> GetProduct(Guid productId);
    public Task<GetProductDto> CreateProduct(CreateProductDto createProductDto, Guid userId);
    public Task<(List<GetProductSimpleDto>, double)> FilterProducts(ProductFilterDto filterDto);
}