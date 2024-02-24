using Application.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Data;

public class UnitOfWork(ApplicationContext context) : IUnitOfWork
{
    private readonly ApplicationContext _context = context;

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    private bool _disposed;

    private void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
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