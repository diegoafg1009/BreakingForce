using Domain.Entities;

namespace Application.Repositories;

public interface ICustomerLockoutInfoRepository : IGenericRepository<CustomerLockoutInfo>
{
    Task<CustomerLockoutInfo?> GetByCustomerIdAsync(Guid customerId);
    Task<CustomerLockoutInfo> AddOrUpdateAsync(CustomerLockoutInfo entity);
}