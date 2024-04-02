using Application.Contracts.Flavor.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Contracts.Flavor.Mappings;

public class FlavorProfile : Profile
{
    public FlavorProfile()
    {
        CreateMap<ProductFlavor, GetFlavor>();
    }
}