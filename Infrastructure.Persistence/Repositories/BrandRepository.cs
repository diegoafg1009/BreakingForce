using Application.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Data;

namespace Infrastructure.Persistence.Repositories;

public class BrandRepository(ApplicationContext context) : GenericRepository<ProductBrand>(context), IBrandRepository
{

}