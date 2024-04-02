using Domain.Entities;

namespace Application.Repositories;

public interface IInventoryRepository : IGenericRepository<ProductInventory>
{
    public Task<ProductInventory?> GetByVariationIdAsync(Guid variationId);
}