using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        //Table
        builder.ToTable("Orders");

        //Primary Key
        builder.HasKey(o => o.Id);

        //Properties
        builder.Property(o => o.Id)
            .HasDefaultValueSql("UUID()")
            .IsRequired();

        builder.Property(o => o.OrderNumber)
            .HasComputedColumnSql($"CONCAT(DATE_FORMAT({nameof(Order.OrderDate)}, '%Y%m%d'), '-', ABS(CONV(SUBSTRING({nameof(Order.Id)}, 1, 8), 16, 10)))")
            .IsRequired();

        builder.Property(o => o.OrderDate)
            .HasDefaultValueSql("NOW()")
            .IsRequired();

        builder.Property(o => o.Note)
            .HasMaxLength(300);

        //Relationships
        builder.HasOne(o => o.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CustomerId)
            .IsRequired(false);

        builder.HasMany(o => o.OrderDetails)
            .WithOne(od => od.Order)
            .HasForeignKey(od => od.OrderId);

        builder.HasOne(o => o.OrderStatus)
            .WithMany(os => os.Orders)
            .HasForeignKey(o => o.OrderStatusId)
            .IsRequired();

        builder.HasOne(o => o.Payment)
            .WithOne(p => p.Order)
            .HasForeignKey<Payment>(p => p.OrderId)
            .IsRequired();

        builder.HasOne(o => o.Shipment)
            .WithOne(s => s.Order)
            .HasForeignKey<Shipment>(s => s.OrderId);

        builder.HasOne(o => o.Coupon)
            .WithMany(c => c.Orders)
            .HasForeignKey(o => o.CouponId);

        builder.HasOne(o => o.Invoice)
            .WithOne(i => i.Order)
            .HasForeignKey<Invoice>(i => i.OrderId)
            .IsRequired();
    }
}