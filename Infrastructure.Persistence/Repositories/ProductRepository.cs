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
    public async Task<IEnumerable<Product>> GetWithFiltersAsync(ProductFilterDto filterDto)
    {
        var products = DbSet
            .Include(x => x.Subcategory)
            .Include(x => x.Brand)
            .Include(x => x.Objective)
            .Include(x => x.Images)
            .Include(x => x.Variations)
            .ThenInclude(y => y.ProductInventory)
            .AsQueryable();


        if (!string.IsNullOrWhiteSpace(filterDto.Search))
        {
            products = products.Where(p => p.Name.Contains(filterDto.Search));
        }

        if (filterDto.SubcategoryId != null)
        {
            products = products.Where(p => p.SubcategoryId == filterDto.SubcategoryId);
        }

        if (filterDto.BrandId != null)
        {
            products = products.Where(p => p.BrandId == filterDto.BrandId);
        }

        if (filterDto.ObjectiveId != null)
        {
            products = products.Where(p => p.ObjectiveId == filterDto.ObjectiveId);
        }

        if (!string.IsNullOrWhiteSpace(filterDto.SortBy))
        {
            var propertyInfo = typeof(Product).GetProperty(filterDto.SortBy);
            if (propertyInfo != null)
            {
                products = filterDto.IsSortAscending
                    ? products.OrderBy(p => propertyInfo.GetValue(p, null))
                    : products.OrderByDescending(p => propertyInfo.GetValue(p, null));
            }
            else
            {
                throw new AppException("Invalid sort by property.");
            }
        }

        products = products.Paginate(filterDto.Page, filterDto.PageSize);

        return await products.ToListAsync();
    }
}