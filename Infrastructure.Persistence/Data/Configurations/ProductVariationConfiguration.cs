using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class ProductVariationConfiguration : IEntityTypeConfiguration<ProductVariation>
{
    public void Configure(EntityTypeBuilder<ProductVariation> builder)
    {
        //Table
        builder.ToTable("ProductVariations");

        //Primary Key
        builder.HasKey(pv => pv.Id);

        //Properties
        builder.Property(pv => pv.Id)
            .HasDefaultValueSql("NEWID()")
            .IsRequired();

        builder.Property(pv => pv.UnitPrice)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(pv => pv.Weight)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(pv => pv.IsActive)
            .HasDefaultValue(true)
            .IsRequired();

        //Relationships
        builder.HasOne(pv => pv.Product)
            .WithMany(p => p.Variations)
            .HasForeignKey(pv => pv.ProductId)
            .IsRequired();

        builder.HasOne(pv => pv.Flavor)
            .WithMany(pf => pf.ProductsVariations)
            .HasForeignKey(pv => pv.FlavorId)
            .IsRequired();

        builder.HasOne(pv => pv.Inventory)
            .WithOne(pi => pi.ProductVariation)
            .HasForeignKey<ProductInventory>(pi => pi.ProductVariationId)
            .IsRequired();

        builder.HasMany(pv => pv.OrderDetails)
            .WithOne(od => od.ProductVariation)
            .HasForeignKey(od => od.ProductVariationId)
            .IsRequired();
    }
}