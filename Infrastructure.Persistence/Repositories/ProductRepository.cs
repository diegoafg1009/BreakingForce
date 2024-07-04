using Application.Contracts.Product.DTOs;
using Application.Exceptions;
using Application.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Data;
using Infrastructure.Persistence.Utils;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class ProductRepository(ApplicationContext context) : GenericRepository<Product>(context), IProductRepository
{
    public override async Task<Product?> GetByIdAsync(Guid id)
    {
        return await DbSet
            .Include(x => x.Subcategory)
            .Include(x => x.Brand)
            .Include(x => x.Objective)
            .Include(x => x.Images)
            .Include(x => x.Variations)
            .ThenInclude(y => y.ProductInventory )
            .Include(x => x.Variations)
            .ThenInclude(y => y.Flavor)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public override async Task<Product> UpdateAsync(Product entity)
    {
        return await Task.Run(() =>
        {
            DbSet.Update(entity);
            return entity;
        });
    }

    public async Task<IQueryable<Product>> GetAllAsQueryable()
    {
        return DbSet
            .Include(x => x.Subcategory)
            .Include(x => x.Brand)
            .Include(x => x.Objective)
            .Include(x => x.Images)
            .Include(x => x.Variations)
            .ThenInclude(y => y.ProductInventory)
            .AsQueryable();
    }
}