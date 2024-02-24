using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class ProductInventoryConfiguration : IEntityTypeConfiguration<ProductInventory>
{
    public void Configure(EntityTypeBuilder<ProductInventory> builder)
    {
//Table
        builder.ToTable("ProductInventories");

        //Primary Key
        builder.HasKey(pi => pi.Id);

        //Properties
        builder.Property(pi => pi.Id)
            .HasDefaultValueSql("NEWID()")
            .IsRequired();

        builder.Property(pi => pi.Quantity)
            .IsRequired();

        //Relationships
        builder.HasOne(pi => pi.Product)
            .WithOne(p => p.Inventory)
            .HasForeignKey<ProductInventory>(pi => pi.Id)
            .IsRequired();
    }
}