using Application.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Data;

namespace Infrastructure.Persistence.Repositories;

public class ObjectiveRepository(ApplicationContext context)
    : GenericRepository<ProductObjective>(context), IObjectiveRepository
{

}