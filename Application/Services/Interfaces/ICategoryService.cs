using Application.Contracts.Category.DTOs;
using Domain.Entities;

namespace Application.Services.Interfaces;

public interface ICategoryService
{
    public Task<List<GetCategory>> GetAllCategories();
}