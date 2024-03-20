using Application.Contracts.Product.DTOs;
using Application.Repositories;
using Application.Services.Interfaces;
using AutoMapper;

namespace Application.Services.Implementations;

public class ProductService(IUnitOfWork unitOfWork, IMapper mapper) : IProductService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<List<GetProductSimpleDto>> FilterProducts(ProductFilterDto filterDto)
    {
        var products = await _unitOfWork.Products.GetWithFiltersAsync(filterDto);
        return _mapper.Map<List<GetProductSimpleDto>>(products) ?? [];
    }
}