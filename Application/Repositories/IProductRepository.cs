using Application.Contracts.Product.DTOs;
using Domain.Entities;

namespace Application.Repositories;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<IQueryable<Product>> GetAllAsQueryable();
}