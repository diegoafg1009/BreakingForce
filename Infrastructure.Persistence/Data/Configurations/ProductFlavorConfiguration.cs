using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class ProductFlavorConfiguration : IEntityTypeConfiguration<ProductFlavor>
{
    public void Configure(EntityTypeBuilder<ProductFlavor> builder)
    {
        //Table
        builder.ToTable("ProductFlavors");

        //Primary Key
        builder.HasKey(pf => pf.Id);

        //Properties
        builder.Property(pf => pf.Id)
            .HasDefaultValueSql("NEWID()")
            .IsRequired();

        builder.Property(pf => pf.Name)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(pf => pf.Color)
            .IsRequired();

        //Relationships
        builder.HasMany(pf => pf.ProductsVariations)
            .WithOne( pv=> pv.Flavor)
            .HasForeignKey(pv => pv.FlavorId);
    }
}