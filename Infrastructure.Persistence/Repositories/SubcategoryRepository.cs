using Application.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Data;

namespace Infrastructure.Persistence.Repositories;

public class SubcategoryRepository(ApplicationContext context)
    : GenericRepository<ProductSubcategory>(context), ISubcategoryRepository;