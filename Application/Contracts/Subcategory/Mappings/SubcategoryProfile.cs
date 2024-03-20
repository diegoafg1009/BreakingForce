using Application.Contracts.Subcategory.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Contracts.Subcategory.Mappings;

public class SubcategoryProfile : Profile
{
    public SubcategoryProfile()
    {
        CreateMap<ProductSubcategory, GetSubcategoryDto>();
    }
}