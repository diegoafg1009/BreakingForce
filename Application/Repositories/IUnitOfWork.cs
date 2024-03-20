namespace Application.Repositories;

public interface IUnitOfWork : IDisposable
{
    IBrandRepository Brands { get; }
    ICategoryRepository Categories { get; }
    IFlavorRepository Flavors { get; }
    IObjectiveRepository Objectives { get; }
    IProductRepository Products { get; }
    ISubcategoryRepository Subcategories { get; }

    Task CommitAsync();
}
