using Application.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class CustomerLockoutInfoRepository(ApplicationContext context)
    : GenericRepository<CustomerLockoutInfo>(context), ICustomerLockoutInfoRepository
{
    public Task<CustomerLockoutInfo?> GetByCustomerIdAsync(Guid customerId)
    {
        return DbSet
            .FirstOrDefaultAsync(cli => cli.CustomerId == customerId);
    }

    public async Task<CustomerLockoutInfo> AddOrUpdateAsync(CustomerLockoutInfo model)
    {
        var customerLockoutInfo = await DbSet
            .FirstOrDefaultAsync(cli => cli.CustomerId == model.CustomerId);

        if (customerLockoutInfo == null)
        {
            return await AddAsync(model);
        }
        else
        {
            return await UpdateAsync(model);
        }
    }
}