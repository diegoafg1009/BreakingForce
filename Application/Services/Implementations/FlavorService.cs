using Application.Contracts.Flavor.DTOs;
using Application.Repositories;
using Application.Services.Interfaces;
using AutoMapper;

namespace Application.Services.Implementations;

public class FlavorService(IUnitOfWork unitOfWork, IMapper mapper) : IFlavorService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<List<GetFlavor>> GetAllFlavors()
    {
        var flavors = await _unitOfWork.Flavors.GetAllAsync();
        return _mapper.Map<List<GetFlavor>>(flavors) ?? [];
    }

}