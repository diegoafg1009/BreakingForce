using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        //Table
        builder.ToTable("Payments");

        //Primary Key
        builder.HasKey(p => p.Id);

        //Properties
        builder.Property(p => p.Id)
            .HasDefaultValueSql("UUID()")
            .IsRequired();

        builder.Property(p => p.ExternalId)
            .IsRequired();

        builder.Property(p => p.Date)
            .HasDefaultValueSql("NOW()")
            .IsRequired();

        //Relationships
        builder.HasOne(p => p.PaymentStatus)
            .WithMany(ps => ps.Payments)
            .HasForeignKey(p => p.PaymentStatusId)
            .IsRequired();

        builder.HasOne(p => p.PaymentMethod)
            .WithMany(pm => pm.Payments)
            .HasForeignKey(p => p.PaymentMethodId)
            .IsRequired();

        builder.HasOne(p => p.Order)
            .WithOne(o => o.Payment)
            .HasForeignKey<Payment>(p => p.OrderId)
            .IsRequired();
    }
}