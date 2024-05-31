using System.Reflection;
using Application.Repositories;
using Domain.Base;
using Domain.Entities;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class VariationRepository(ApplicationContext context)
    : GenericRepository<ProductVariation>(context), IVariationRepository
{
    public override async Task<ProductVariation?> GetByIdAsync(Guid id)
    {
        return await DbSet
            .Include(v => v.Product)
            .ThenInclude(v => v.Images)
            .Include(v => v.ProductInventory)
            .Include(v => v.Flavor)
            .FirstOrDefaultAsync(v => v.Id == id);
    }

    public override async Task<IEnumerable<ProductVariation>> GetRangeByIdsAsync(IEnumerable<Guid> ids)
    {
        return await DbSet
            .Include(v => v.Product)
            .ThenInclude(v => v.Images)
            .Include(v => v.ProductInventory)
            .Include(v => v.Flavor)
            .Where(v => ids.Contains(v.Id))
            .ToListAsync();
    }
}