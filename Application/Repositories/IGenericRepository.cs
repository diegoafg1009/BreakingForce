using System.Linq.Expressions;

namespace Application.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<T> AddAsync(T entity);
    Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);
    Task<T> UpdateAsync(T entity);
    Task<T?> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetRangeByIdsAsync(IEnumerable<Guid> ids);
    Task<IEnumerable<T>> GetAllAsync();
    Task<int> CountAsync(Expression<Func<T, bool>>? predicate);
    Task<IEnumerable<T>> GetWithFilterAsync(Expression<Func<T, bool>> predicate);
    Task DeleteAsync(Guid id);
    Task DeleteRangeAsync(IEnumerable<T> entities);
}

