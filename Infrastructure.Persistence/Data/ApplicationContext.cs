using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Data;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    #region DbSets

    DbSet<Address> Addresses { get; set; }
    DbSet<Coupon> Coupons { get; set; }
    DbSet<Customer> Customers { get; set; }
    DbSet<DeliveryMethod> DeliveryMethods { get; set; }
    DbSet<Department> Departments { get; set; }
    DbSet<District> Districts { get; set; }
    DbSet<EnterpriseData> EnterpriseData { get; set; }
    DbSet<Identification> Identifications { get; set; }
    DbSet<IdentificationType> IdentificationTypes { get; set; }
    DbSet<Invoice> Invoices { get; set; }
    DbSet<Order> Orders { get; set; }
    DbSet<OrderDetail> OrderDetails { get; set; }
    DbSet<OrderStatus> OrderStatuses { get; set; }
    DbSet<PaymentMethod> PaymentMethods { get; set; }
    DbSet<Product> Products { get; set; }
    DbSet<ProductBrand> ProductBrands { get; set; }
    DbSet<ProductCategory> ProductCategories { get; set; }
    DbSet<ProductImage> ProductImages { get; set; }
    DbSet<ProductInventory> ProductInventories { get; set; }
    DbSet<ProductObjective> ProductObjectives { get; set; }
    DbSet<ProductSubcategory> ProductSubcategories { get; set; }
    DbSet<Province> Provinces { get; set; }
    DbSet<Shipment> Shipments { get; set; }
    DbSet<Transaction> Transactions { get; set; }
    DbSet<TransactionDetail> TransactionDetails { get; set; }
    DbSet<TransactionType> TransactionTypes { get; set; }

    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);
    }
}