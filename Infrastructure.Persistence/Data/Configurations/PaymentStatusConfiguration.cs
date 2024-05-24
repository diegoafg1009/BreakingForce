using Domain.Entities;
using Infrastructure.Persistence.Data.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class PaymentStatusConfiguration : IEntityTypeConfiguration<PaymentStatus>
{
    public void Configure(EntityTypeBuilder<PaymentStatus> builder)
    {
        //Table
        builder.ToTable("PaymentStatuses");

        //Primary Key
        builder.HasKey(ps => ps.Id);

        //Properties
        builder.Property(ps => ps.Id)
            .HasDefaultValueSql("UUID()")
            .IsRequired();

        builder.Property(ps => ps.Name)
            .HasMaxLength(50)
            .IsRequired();

        //Relationships
        builder.HasMany(ps => ps.Payments)
            .WithOne(p => p.PaymentStatus)
            .HasForeignKey(p => p.PaymentStatusId)
            .IsRequired();

        //Seed Data
        builder.HasData(DefaultPaymentStatuses.Seed());
    }
}