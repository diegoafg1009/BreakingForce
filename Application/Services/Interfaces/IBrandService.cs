using Application.Contracts.Brand.DTOs;
using Application.Contracts.Product.DTOs;
using Domain.Entities;

namespace Application.Services.Interfaces;

public interface IBrandService
{
    public Task<GetBrandDto> CreateBrand(CreateBrandDto createBrandDto);
    public Task<List<GetBrandDto>> GetAllBrands();
}