using System.Linq.Expressions;

namespace Application.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T?> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<int> CountAsync(Expression<Func<T, bool>>? predicate);
}

