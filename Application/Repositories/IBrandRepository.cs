using Domain.Entities;

namespace Application.Repositories;

public interface IBrandRepository : IGenericRepository<ProductBrand>
{
    Task<IEnumerable<ProductBrand>> GetAllWithAnyProductAsync();
}