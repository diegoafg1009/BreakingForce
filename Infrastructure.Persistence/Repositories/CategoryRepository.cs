using Application.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Data;

namespace Infrastructure.Persistence.Repositories;

public class CategoryRepository(ApplicationContext context)
    : GenericRepository<ProductCategory>(context), ICategoryRepository
{

}