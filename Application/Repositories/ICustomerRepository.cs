using Domain.Entities;

namespace Application.Repositories;

public interface ICustomerRepository : IGenericRepository<Customer>
{
    Task<Customer?> GetByEmailAsync(string email);
    bool VerifyPassword(Customer customer, string password);
}