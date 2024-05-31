using Application.Repositories;
using Application.Services.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class CustomerRepository(ApplicationContext context) : GenericRepository<Customer>(context), ICustomerRepository
{
    public override async Task<Customer> AddAsync(Customer entity)
    {
        entity.CreatedAt = DateTime.Now;
        entity.UpdatedAt = DateTime.Now;
        entity.Password = BCrypt.Net.BCrypt.HashPassword(entity.Password);

        return await base.AddAsync(entity);
    }

    public async Task<Customer?> GetByEmailAsync(string email)
    {
        return await DbSet.FirstOrDefaultAsync(c => c.Email.ToUpper() == email.ToUpper());
    }

    public bool VerifyPassword(Customer customer, string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, customer.Password);
    }
}