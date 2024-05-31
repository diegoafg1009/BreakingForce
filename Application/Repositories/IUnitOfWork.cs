namespace Application.Repositories;

public interface IUnitOfWork : IDisposable
{
    IBrandRepository Brands { get; }
    ICategoryRepository Categories { get; }
    ICustomerRepository Customers { get; }
    ICustomerLockoutInfoRepository CustomerLockoutInfos { get; }
    ICustomerRegisterConfirmationRepository CustomerRegisterConfirmationsRepository { get; }
    IFlavorRepository Flavors { get; }
    IInventoryRepository Inventories { get; }
    IObjectiveRepository Objectives { get; }
    IProductImageRepository ProductImages { get; }
    IProductRepository Products { get; }
    ISubcategoryRepository Subcategories { get; }
    ITransactionRepository Transactions { get; }
    IVariationRepository Variations { get; }

    Task CommitAsync();
}
