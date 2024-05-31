using Application.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class CustomerRegisterConfirmationRepository(ApplicationContext context)
    : GenericRepository<CustomerRegisterConfirmation>(context), ICustomerRegisterConfirmationRepository
{
    public Task<CustomerRegisterConfirmation?> GetByToken(string token)
    {
        var customerRegisterConfirmation = DbSet.FirstOrDefaultAsync(c => c.Token == token);
        return customerRegisterConfirmation;
    }

    public Task<CustomerRegisterConfirmation?> GetByCustomerIdAsync(Guid customerId)
    {
        var customerRegisterConfirmation = DbSet.FirstOrDefaultAsync(c => c.CustomerId == customerId);
        return customerRegisterConfirmation;
    }

    public Task<CustomerRegisterConfirmation?> GetByCustomerEmailAsync(string email)
    {
        var customerRegisterConfirmation = DbSet
            .Include(c => c.Customer)
            .FirstOrDefaultAsync(c => c.Customer.Email.ToUpper() == email.ToUpper());
        return customerRegisterConfirmation;
    }
}