using Application.Contracts.Category.DTOs;
using Application.Repositories;
using Application.Services.Interfaces;
using AutoMapper;

namespace Application.Services.Implementations;

public class CategoryService(IUnitOfWork unitOfWork, IMapper mapper) : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<List<GetCategory>> GetAllCategories()
    {
        var categories = await _unitOfWork.Categories.GetAllAsync();
        return _mapper.Map<List<GetCategory>>(categories) ?? [];
    }
}