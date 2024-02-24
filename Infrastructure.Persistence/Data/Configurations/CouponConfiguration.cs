using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class CouponConfiguration : IEntityTypeConfiguration<Coupon>
{
    public void Configure(EntityTypeBuilder<Coupon> builder)
    {
        //Table
        builder.ToTable("Coupons");

        //Primary Key
        builder.HasKey(c => c.Id);

        //Properties

        builder.Property(c => c.Id)
            .HasDefaultValueSql("NEWID()")
            .IsRequired();

        builder.Property(c => c.Code)
            .HasMaxLength(15)
            .IsRequired();

        builder.Property(c => c.Discount)
            .HasColumnType("decimal(5,2)")
            .IsRequired();

        builder.Property(c => c.StartDate)
            .IsRequired();

        builder.Property(c => c.ExpirationDate)
            .IsRequired();

        builder.Property(c => c.IsActive)
            .IsRequired();

        builder.Property(c => c.IsOneUseOnly)
            .IsRequired();

        //Relationships
        builder.HasMany(e => e.Orders)
            .WithOne(e => e.Coupon)
            .HasForeignKey(e => e.CouponId);
    }
}