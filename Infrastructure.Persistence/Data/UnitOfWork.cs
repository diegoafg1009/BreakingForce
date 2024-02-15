using Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Data;

public class UnitOfWork(DbContext context) : IUnitOfWork
{
    public async Task CommitAsync()
    {
        await context.SaveChangesAsync();
    }

    private bool _disposed;

    private void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
