using Application.Contracts.Brand.DTOs;
using Application.Contracts.Product.DTOs;
using Domain.Entities;

namespace Application.Services.Interfaces;

public interface IBrandService
{
    public Task<GetBrand> CreateBrand(CreateBrand createBrand);
    public Task<List<GetBrand>> GetAllBrands();
    public Task<List<GetBrand>> GetAllWithAnyProduct();
}