using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        //Table
        builder.ToTable("OrderDetails");

        //Primary Key
        builder.HasKey(od => new { od.OrderId, od.ProductVariationId });

        //Properties
        builder.Property(od => od.Quantity)
            .IsRequired();

        builder.Property(od => od.UnitPrice)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(od => od.Tax)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(od => od.Discount)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(od => od.Amount)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        //Relationships
        builder.HasOne(od => od.Order)
            .WithMany(o => o.OrderDetails)
            .HasForeignKey(od => od.OrderId)
            .IsRequired();

        builder.HasOne(od => od.ProductVariation)
            .WithMany(p => p.OrderDetails)
            .HasForeignKey(od => od.ProductVariationId)
            .IsRequired();
    }
}