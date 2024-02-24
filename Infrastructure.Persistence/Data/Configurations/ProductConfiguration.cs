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
            .HasDefaultValueSql("NEWID()")
            .IsRequired();

        builder.Property(p => p.Name)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(p => p.Description)
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(p => p.UnitPrice)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        //Relationships
        builder.HasOne(p => p.Category)
            .WithMany(ps => ps.Products)
            .HasForeignKey(p => p.CategoryId)
            .IsRequired();

        builder.HasOne(p => p.Objective)
            .WithMany(po => po.Products)
            .HasForeignKey(p => p.ObjectiveId)
            .IsRequired();

        builder.HasOne(p => p.Brand)
            .WithMany(b => b.Products)
            .HasForeignKey(p => p.BrandId)
            .IsRequired();

        builder.HasOne(p => p.Inventory)
            .WithOne(i => i.Product)
            .HasForeignKey<Product>(p => p.InventoryId)
            .IsRequired();

        builder.HasMany(p => p.Images)
            .WithOne(pi => pi.Product)
            .HasForeignKey(pi => pi.ProductId)
            .IsRequired();

        builder.HasMany(p => p.OrderDetails)
            .WithOne(od => od.Product)
            .HasForeignKey(od => od.ProductId)
            .IsRequired();
    }
}