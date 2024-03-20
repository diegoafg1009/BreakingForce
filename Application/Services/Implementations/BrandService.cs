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

    public async Task<GetBrandDto> CreateBrand(CreateBrandDto createBrandDto)
    {
        var brand = _mapper.Map<ProductBrand>(createBrandDto)!;

        await _fileStorageService.SaveFile(brand.Image, createBrandDto.Image.OpenReadStream());

        await _unitOfWork.Brands.AddAsync(brand);
        await _unitOfWork.CommitAsync();
        return _mapper.Map<GetBrandDto>(brand)!;
    }

    public async Task<List<GetBrandDto>> GetAllBrands()
    {
        var brands = await _unitOfWork.Brands.GetAllAsync();
        return _mapper.Map<List<GetBrandDto>>(brands) ?? [];
    }
}