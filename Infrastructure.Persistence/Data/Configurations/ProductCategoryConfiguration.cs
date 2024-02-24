using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        //Table
        builder.ToTable("ProductCategories");

        //Primary Key
        builder.HasKey(pc => pc.Id);

        //Properties
        builder.Property(pc => pc.Id)
            .HasDefaultValueSql("NEWID()")
            .IsRequired();

        builder.Property(pc => pc.Name)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(pc => pc.Description)
            .HasMaxLength(500)
            .IsRequired();

        //Relationships
        builder.HasMany(pc => pc.Subcategories)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId)
            .IsRequired();
    }
}