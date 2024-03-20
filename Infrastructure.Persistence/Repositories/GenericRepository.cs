using System.Linq.Expressions;
using Application.Repositories;
using Infrastructure.Persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository <T> where T : class
{
    private readonly ApplicationContext _context;
    internal DbSet<T> DbSet;

    protected GenericRepository(ApplicationContext context)
    {
        _context = context;
        DbSet = _context.Set<T>();
    }


    public virtual async Task<T> AddAsync(T entity)
    {
        await DbSet.AddAsync(entity);
        return entity;
    }

    public virtual async Task<T> UpdateAsync(T entity)
    {
        return await Task.Run(() =>
        {
            DbSet.Update(entity);
            return entity;
        });
    }

    public virtual async Task<T?> GetByIdAsync(Guid id)
    {
        return await DbSet.FindAsync(id);
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        return await DbSet.ToListAsync();
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
    {
        if (predicate is null)
        {
            return await DbSet.CountAsync();
        }

        return await DbSet.CountAsync(predicate);
    }

    public async Task<IEnumerable<T>> GetWithFilterAsync(Expression<Func<T, bool>> predicate)
    {
        return await Task.Run(() => DbSet.Where(predicate).AsEnumerable());
    }
}
