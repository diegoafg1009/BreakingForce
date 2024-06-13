using Application.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class BrandRepository(ApplicationContext context) : GenericRepository<ProductBrand>(context), IBrandRepository
{
    public async Task<IEnumerable<ProductBrand>> GetAllWithAnyProductAsync()
    {
        return await DbSet.Where(x => x.Products.Any(y => y.Variations.Any(z => z.IsActive))).ToListAsync();
    }
}