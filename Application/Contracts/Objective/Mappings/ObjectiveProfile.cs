using Application.Contracts.Objective.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Contracts.Objective.Mappings;

public class ObjectiveProfile : Profile
{
    public ObjectiveProfile()
    {
        CreateMap<ProductObjective, GetObjectiveDto>();
    }
}