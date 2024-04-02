using Application.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class InventoryRepository(ApplicationContext context)
    : GenericRepository<ProductInventory>(context), IInventoryRepository
{
    public async Task<ProductInventory?> GetByVariationIdAsync(Guid variationId)
    {
        return await DbSet
            .FirstOrDefaultAsync(pi => pi.ProductVariation.Id == variationId);
    }
}