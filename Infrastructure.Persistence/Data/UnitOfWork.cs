using Application.Repositories;
using Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Data;

public class UnitOfWork(ApplicationContext context) : IUnitOfWork
{
    public IBrandRepository Brands { get; } = new BrandRepository(context);
    public ICategoryRepository Categories { get; } = new CategoryRepository(context);
    public IFlavorRepository Flavors { get; } = new FlavorRepository(context);
    public IObjectiveRepository Objectives { get; } = new ObjectiveRepository(context);
    public IProductRepository Products { get; } = new ProductRepository(context);
    public ISubcategoryRepository Subcategories { get; } = new SubcategoryRepository(context);
    public ITransactionRepository Transactions { get; } = new TransactionRepository(context);

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