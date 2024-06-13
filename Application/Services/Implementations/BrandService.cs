using Application.Contracts.Brand.DTOs;
using Application.Repositories;
using Application.Services.Interfaces;
using AutoMapper;
using Domain.Entities;

namespace Application.Services.Implementations;

public class BrandService(IUnitOfWork unitOfWork, IMapper mapper, IFileStorageService fileStorageService)
    : IBrandService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;
    private readonly IFileStorageService _fileStorageService = fileStorageService;

    public async Task<GetBrand> CreateBrand(CreateBrand createBrand)
    {
        var brand = _mapper.Map<ProductBrand>(createBrand)!;

        await _fileStorageService.SaveFile(brand.Image, createBrand.Image.OpenReadStream());

        await _unitOfWork.Brands.AddAsync(brand);
        await _unitOfWork.CommitAsync();
        return _mapper.Map<GetBrand>(brand)!;
    }

    public async Task<List<GetBrand>> GetAllBrands()
    {
        var brands = (await _unitOfWork.Brands.GetAllWithAnyProductAsync());
        return _mapper.Map<List<GetBrand>>(brands) ?? [];
    }
}