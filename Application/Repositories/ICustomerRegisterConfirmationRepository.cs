using Domain.Entities;

namespace Application.Repositories;

public interface ICustomerRegisterConfirmationRepository : IGenericRepository<CustomerRegisterConfirmation>
{
    Task<CustomerRegisterConfirmation?> GetByToken(string token);
    Task<CustomerRegisterConfirmation?> GetByCustomerIdAsync(Guid customerId);
    Task<CustomerRegisterConfirmation?> GetByCustomerEmailAsync(string email);
}