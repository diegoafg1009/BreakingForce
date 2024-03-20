namespace Infrastructure.Persistence.Utils;

public static class QueryableExtension
{
    public static IQueryable<T> Paginate<T>(this IQueryable<T> queryable, int page, int pageSize)
    {
        return queryable.Skip((page - 1) * pageSize).Take(pageSize);
    }
}