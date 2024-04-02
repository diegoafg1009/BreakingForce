using Application.Contracts.Objective.DTOs;
using Domain.Entities;

namespace Application.Services.Interfaces;

public interface IObjectiveService
{
    public Task<List<GetObjective>> GetAllObjectives();
}