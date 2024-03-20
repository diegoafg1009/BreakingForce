using Application.Contracts.Flavor.DTOs;
using Domain.Entities;

namespace Application.Services.Interfaces;

public interface IFlavorService
{
    public Task<List<GetFlavorDto>> GetAllFlavors();
}