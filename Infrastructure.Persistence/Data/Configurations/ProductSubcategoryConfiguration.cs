using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class ProductSubcategoryConfiguration : IEntityTypeConfiguration<ProductSubcategory>
{
    public void Configure(EntityTypeBuilder<ProductSubcategory> builder)
    {
        //Table
        builder.ToTable("ProductSubcategories");

        //Primary Key
        builder.HasKey(ps => ps.Id);

        //Properties
        builder.Property(ps => ps.Id)
            .HasDefaultValueSql("NEWID()")
            .IsRequired();

        builder.Property(ps => ps.Name)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(ps => ps.Description)
            .HasMaxLength(500)
            .IsRequired();

        //Relationships
        builder.HasOne(ps => ps.Category)
            .WithMany(c => c.Subcategories)
            .HasForeignKey(ps => ps.CategoryId)
            .IsRequired();

        builder.HasMany(ps => ps.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId);
    }
}