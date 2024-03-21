using Application.Contracts.Variation.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Contracts.Variation.Mappings;

public class VariationProfile : Profile
{
    public VariationProfile()
    {
        CreateMap<CreateVariation, ProductVariation>()
            .ForMember(dest => dest.ProductInventory, opt => opt.MapFrom(src => new ProductInventory(src.Stock)))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true));
        CreateMap<ProductVariation, GetVariationDto>()
            .ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.ProductInventory.Quantity))
            .ForMember(dest => dest.FlavorName, opt => opt.MapFrom(src =>  src.Flavor != null ? src.Flavor.Name : null))
            .ForMember(dest => dest.FlavorColor, opt => opt.MapFrom(src => src.Flavor != null ? src.Flavor.Color : null));
    }
}