using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
{
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        //Table
        builder.ToTable("ProductImages");

        //Primary Key
        builder.HasKey(pi => pi.Id);

        //Properties
        builder.Property(pi => pi.Id)
            .HasDefaultValueSql("NEWID()")
            .IsRequired();

        builder.Property(pi => pi.Url)
            .IsRequired();

        //Relationships
        builder.HasOne(pi => pi.Product)
            .WithMany(p => p.Images)
            .HasForeignKey(pi => pi.ProductId)
            .IsRequired();
    }
}