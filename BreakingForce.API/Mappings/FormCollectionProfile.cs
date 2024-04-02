using Application.Contracts.Brand.DTOs;
using Application.Contracts.Product.DTOs;
using Application.Contracts.Variation.DTOs;
using AutoMapper;
using Newtonsoft.Json;

namespace BreakingForce.API.Mappings;

public class FormCollectionProfile : Profile
{
    public FormCollectionProfile()
    {
        CreateMap<IFormCollection, CreateBrand>()
            .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Files[0]))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src["name"]));

        CreateMap<IFormCollection, CreateProduct>()
            .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Files))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src["name"]))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src["description"]))
            .ForMember(dest => dest.SubcategoryId, opt => opt.MapFrom(src => Guid.Parse(src["subcategoryId"]!)))
            .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => Guid.Parse(src["brandId"]!)))
            .ForMember(dest => dest.ObjectiveId, opt => opt.MapFrom(src => Guid.Parse(src["objectiveId"]!)))
            .ForMember(dest => dest.Variations, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<List<CreateVariation>>($"[{src["variations"]}]")));

        CreateMap<IFormCollection, UpdateProduct>()
            .ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.Files))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src["name"]))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src["description"]))
            .ForMember(dest => dest.SubcategoryId, opt => opt.MapFrom(src => Guid.Parse(src["subcategoryId"]!)))
            .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => Guid.Parse(src["brandId"]!)))
            .ForMember(dest => dest.ObjectiveId, opt => opt.MapFrom(src => Guid.Parse(src["objectiveId"]!)))
            .ForMember(dest => dest.Variations, opt => opt.MapFrom(src => JsonConvert.DeserializeObject<List<UpdateVariation>>($"[{src["variations"]}]")));

    }
}