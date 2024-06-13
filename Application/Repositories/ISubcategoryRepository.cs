using Domain.Entities;

namespace Application.Repositories;

public interface ISubcategoryRepository : IGenericRepository<ProductSubcategory>
{
    Task<IEnumerable<ProductSubcategory>> GetAllWithAnyProductAsync();
}