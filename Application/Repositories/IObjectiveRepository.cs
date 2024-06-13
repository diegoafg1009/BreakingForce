using Domain.Entities;

namespace Application.Repositories;

public interface IObjectiveRepository : IGenericRepository<ProductObjective>
{
    Task<IEnumerable<ProductObjective>> GetAllWithAnyProductAsync();
}