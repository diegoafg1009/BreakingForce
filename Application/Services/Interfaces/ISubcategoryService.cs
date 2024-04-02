using Application.Contracts.Subcategory.DTOs;

namespace Application.Services.Interfaces;

public interface ISubcategoryService
{
    Task<List<GetSubcategory>> GetAllSubcategories();
}