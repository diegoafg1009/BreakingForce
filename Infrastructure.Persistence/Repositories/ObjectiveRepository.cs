using Application.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class ObjectiveRepository(ApplicationContext context)
    : GenericRepository<ProductObjective>(context), IObjectiveRepository
{
    public async Task<IEnumerable<ProductObjective>> GetAllWithAnyProductAsync()
    {
        return await DbSet.Where(x => x.Products.Any(y => y.Variations.Any(z => z.IsActive))).ToListAsync();
    }

}