using Application.Contracts.Product.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Contracts.Product.Mappings;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<Domain.Entities.Product, GetProductSimpleDto>()
            .ForMember(dest => dest.LowerPrice, opt => opt.MapFrom(src => src.Variations.Min(v => v.UnitPrice)))
            .ForMember(dest => dest.HigherPrice, opt => opt.MapFrom(src => src.Variations.Max(v => v.UnitPrice)))
            .ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.Variations.Sum(v => v.ProductInventory.Quantity)))
            .ForMember(dest => dest.Subcategory, opt => opt.MapFrom(src => src.Subcategory.Name))
            .ForMember(dest => dest.Objective, opt => opt.MapFrom(src => src.Objective.Name))
            .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand.Name))
            .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Images.FirstOrDefault()!.Url));
        CreateMap<CreateProductDto, Domain.Entities.Product>()
            .ForMember(dest => dest.IsActive , opt => opt.MapFrom(src => true))
            .ForMember(dest => dest.Images,
                opt => opt.MapFrom(src => src.Images.Select((i, index) =>
                    new ProductImage($"products/{Guid.NewGuid().ToString()}{Path.GetExtension(i.FileName)}",
                        index + 1))))
            .ForMember(dest => dest.Variations, opt => opt.MapFrom(src => src.Variations));
        CreateMap<Domain.Entities.Product, GetProductDto>()
            .ForMember(dest => dest.LowerPrice, opt => opt.MapFrom(src => src.Variations.Min(v => v.UnitPrice)))
            .ForMember(dest => dest.HigherPrice, opt => opt.MapFrom(src => src.Variations.Max(v => v.UnitPrice)))
            .ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.Variations.Sum(v => v.ProductInventory.Quantity)))
            .ForMember(dest => dest.Subcategory, opt => opt.MapFrom(src => src.Subcategory.Name))
            .ForMember(dest => dest.Objective, opt => opt.MapFrom(src => src.Objective.Name))
            .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand.Name))
            .ForMember(dest => dest.Images,
                opt => opt.MapFrom(src => src.Images.OrderBy(i => i.Order).Select(i => i.Url)))
            .ForMember(dest => dest.Variations, opt => opt.MapFrom(src => src.Variations));
    }
}