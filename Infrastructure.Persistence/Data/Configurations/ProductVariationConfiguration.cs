using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class ProductVariationConfiguration : IEntityTypeConfiguration<ProductVariation>
{
    public void Configure(EntityTypeBuilder<ProductVariation> builder)
    {
        //Table
        builder.ToTable("ProductVariations",
            pv => pv.HasCheckConstraint("CK_ProductVariations_MeasureUnit",
                "MeasureUnit IN ('g', 'kg', 'l', 'ml', 'und', 'caja', 'cajas', 'lb', 'botella', 'botellas')"));

        //Primary Key
        builder.HasKey(pv => pv.Id);

        //Properties
        builder.Property(pv => pv.Id)
            .HasDefaultValueSql("UUID()")
            .IsRequired();

        builder.Property(pv => pv.UnitPrice)
            .HasColumnType("DECIMAL(18,2)")
            .IsRequired();

        builder.Property(pv => pv.Weight)
            .HasColumnType("DECIMAL(18,2)")
            .IsRequired();

        builder.Property(pv => pv.MeasureUnit)
            .HasDefaultValue("kg")
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
            .HasForeignKey(pv => pv.FlavorId);

        builder.HasOne(pv => pv.ProductInventory)
            .WithOne(pi => pi.ProductVariation)
            .HasForeignKey<ProductVariation>(pv => pv.ProductInventoryId)
            .IsRequired();

        builder.HasMany(pv => pv.OrderDetails)
            .WithOne(od => od.ProductVariation)
            .HasForeignKey(od => od.ProductVariationId)
            .IsRequired();
    }
}