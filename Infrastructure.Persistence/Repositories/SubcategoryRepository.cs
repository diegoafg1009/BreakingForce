using Application.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class SubcategoryRepository(ApplicationContext context)
    : GenericRepository<ProductSubcategory>(context), ISubcategoryRepository
{
    public async Task<IEnumerable<ProductSubcategory>> GetAllWithAnyProductAsync()
    {
        return await DbSet.Where(x => x.Products.Any(y => y.Variations.Any(z => z.IsActive))).ToListAsync();
    }
}