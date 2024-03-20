using Application.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Data;

namespace Infrastructure.Persistence.Repositories;

public class FlavorRepository(ApplicationContext context)
    : GenericRepository<ProductFlavor>(context), IFlavorRepository
{

}