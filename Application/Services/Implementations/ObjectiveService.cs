using Application.Contracts.Objective.DTOs;
using Application.Repositories;
using Application.Services.Interfaces;
using AutoMapper;

namespace Application.Services.Implementations;

public class ObjectiveService(IUnitOfWork unitOfWork, IMapper mapper) : IObjectiveService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<List<GetObjective>> GetAllObjectives()
    {
        var objectives = await _unitOfWork.Objectives.GetAllWithAnyProductAsync();
        return _mapper.Map<List<GetObjective>>(objectives) ?? [];
    }
}