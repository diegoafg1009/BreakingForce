using Application.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class VariationRepository(ApplicationContext context)
    : GenericRepository<ProductVariation>(context), IVariationRepository
{
    public override Task<ProductVariation?> GetByIdAsync(Guid id)
    {
        return DbSet
            .Include(v => v.Product)
            .ThenInclude(v => v.Images)
            .Include(v => v.ProductInventory)
            .Include(v => v.Flavor)
            .FirstOrDefaultAsync(v => v.Id == id);
    }
}