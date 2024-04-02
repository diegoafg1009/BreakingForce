using Application.Contracts.Subcategory.DTOs;
using Application.Repositories;
using Application.Services.Interfaces;
using AutoMapper;

namespace Application.Services.Implementations;

public class SubcategoryService(IUnitOfWork unitOfWork, IMapper mapper) : ISubcategoryService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<List<GetSubcategory>> GetAllSubcategories()
    {
        var subcategories = await _unitOfWork.Subcategories.GetAllAsync();
        return _mapper.Map<List<GetSubcategory>>(subcategories) ?? [];
    }
}