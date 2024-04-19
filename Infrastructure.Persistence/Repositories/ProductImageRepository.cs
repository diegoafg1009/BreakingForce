using Application.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Data;

namespace Infrastructure.Persistence.Repositories;

public class ProductImageRepository(ApplicationContext context)
    : GenericRepository<ProductImage>(context), IProductImageRepository;