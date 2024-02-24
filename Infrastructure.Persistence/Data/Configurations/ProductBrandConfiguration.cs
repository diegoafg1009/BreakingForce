using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class ProductBrandConfiguration : IEntityTypeConfiguration<ProductBrand>
{
    public void Configure(EntityTypeBuilder<ProductBrand> builder)
    {
        //Table
        builder.ToTable("ProductBrands");

        //Primary Key
        builder.HasKey(pb => pb.Id);

        //Properties
        builder.Property(pb => pb.Id)
            .HasDefaultValueSql("NEWID()")
            .IsRequired();

        builder.Property(pb => pb.Name)
            .HasMaxLength(150)
            .IsRequired();

        //Relationships
        builder.HasMany(pb => pb.Products)
            .WithOne(p => p.Brand)
            .HasForeignKey(p => p.BrandId)
            .IsRequired();
    }
}