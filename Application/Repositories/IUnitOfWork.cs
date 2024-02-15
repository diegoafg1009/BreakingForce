namespace Application.Repositories;

public interface IUnitOfWork : IDisposable
{
    Task CommitAsync();
}
