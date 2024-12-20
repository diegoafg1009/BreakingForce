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
            .HasDefaultValueSql("UUID()")
            .IsRequired();

        builder.Property(pi => pi.Quantity)
            .IsRequired();

        //Relationships
        builder.HasOne(pi => pi.ProductVariation)
            .WithOne(pv => pv.ProductInventory)
            .HasForeignKey<ProductVariation>(pv => pv.ProductInventoryId)
            .IsRequired();
    }
}