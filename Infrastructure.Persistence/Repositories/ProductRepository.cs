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

    public async Task<(IEnumerable<Product>, double)> GetWithFiltersAsync(ProductFilterDto filterDto)
    {
        var queryable = DbSet
            .Include(x => x.Subcategory)
            .Include(x => x.Brand)
            .Include(x => x.Objective)
            .Include(x => x.Images)
            .Include(x => x.Variations)
            .ThenInclude(y => y.ProductInventory)
            .AsQueryable();


        if (!string.IsNullOrWhiteSpace(filterDto.Search))
        {
            queryable = queryable.Where(p => p.Name.Contains(filterDto.Search));
        }

        if (filterDto.SubcategoryId != null)
        {
            queryable = queryable.Where(p => p.SubcategoryId == filterDto.SubcategoryId);
        }

        if (filterDto.BrandId != null)
        {
            queryable = queryable.Where(p => p.BrandId == filterDto.BrandId);
        }

        if (filterDto.ObjectiveId != null)
        {
            queryable = queryable.Where(p => p.ObjectiveId == filterDto.ObjectiveId);
        }

        if (!string.IsNullOrWhiteSpace(filterDto.SortBy))
        {
            var propertyInfo = typeof(Product).GetProperty(filterDto.SortBy);
            if (propertyInfo != null)
            {
                queryable = filterDto.IsSortAscending
                    ? queryable.OrderBy(p => propertyInfo.GetValue(p, null))
                    : queryable.OrderByDescending(p => propertyInfo.GetValue(p, null));
            }
            else
            {
                throw new AppException("Invalid sort by property.");
            }
        }

        var totalRecords = await queryable.CountAsync();

        var products = await queryable.Paginate(filterDto.Page, filterDto.PageSize).ToListAsync();

        return (products, totalRecords);
    }
}