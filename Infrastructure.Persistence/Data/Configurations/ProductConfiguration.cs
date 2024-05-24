using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        //Table
        builder.ToTable("Products");

        //Primary Key
        builder.HasKey(p => p.Id);

        //Properties
        builder.Property(p => p.Id)
            .HasDefaultValueSql("UUID()")
            .IsRequired();

        builder.Property(p => p.Name)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(p => p.Description)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(p => p.IsActive)
            .HasDefaultValue(true)
            .IsRequired();

        //Relationships
        builder.HasOne(p => p.Subcategory)
            .WithMany(ps => ps.Products)
            .HasForeignKey(p => p.SubcategoryId)
            .IsRequired();

        builder.HasOne(p => p.Objective)
            .WithMany(po => po.Products)
            .HasForeignKey(p => p.ObjectiveId)
            .IsRequired();

        builder.HasOne(p => p.Brand)
            .WithMany(b => b.Products)
            .HasForeignKey(p => p.BrandId)
            .IsRequired();

        builder.HasMany(p => p.Images)
            .WithOne(pi => pi.Product)
            .HasForeignKey(pi => pi.ProductId)
            .IsRequired();

        builder.HasMany(p => p.Variations)
            .WithOne(pv => pv.Product)
            .HasForeignKey(pv => pv.ProductId)
            .IsRequired();
    }
}