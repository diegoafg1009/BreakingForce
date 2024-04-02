using Application.Contracts.Brand.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Contracts.Brand.Mappings;

public class BrandProfile : Profile
{
    public BrandProfile()
    {
        CreateMap<ProductBrand, GetBrand>()
            .ForMember(dest => dest.ImageUrl,
                opt => opt.MapFrom(src => src.Image));
        CreateMap<CreateBrand, ProductBrand>()
            .ForMember(dest => dest.Image,
                opt => opt.MapFrom(src =>
                    $"brands/{Guid.NewGuid().ToString()}{Path.GetExtension(src.Image.FileName)}"));
    }
}