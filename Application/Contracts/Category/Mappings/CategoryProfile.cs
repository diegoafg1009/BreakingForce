using Application.Contracts.Category.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Contracts.Category.Mappings;

public class CategoryProfile : Profile
{
    public CategoryProfile()
    {
        CreateMap<ProductCategory, GetCategory>();
    }
}