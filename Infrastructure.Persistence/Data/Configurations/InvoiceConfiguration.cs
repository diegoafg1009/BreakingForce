using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
{
    public void Configure(EntityTypeBuilder<Invoice> builder)
    {
        //Table
        builder.ToTable("Invoices");

        //Primary Key
        builder.HasKey(i => i.Id);

        //Properties
        builder.Property(i => i.Id)
            .HasDefaultValueSql("UUID()")
            .IsRequired();

        builder.Property(i => i.IdentificationTypeId)
            .IsRequired();

        builder.Property(i => i.IdentificationNumber)
            .HasMaxLength(9)
            .IsRequired();

        builder.Property(i => i.Ruc)
            .HasMaxLength(11);

        builder.Property(i => i.BusinessName)
            .HasMaxLength(250);

        builder.Property(i => i.SubTotal)
            .HasColumnType("DECIMAL(18,2)")
            .IsRequired();

        builder.Property(i => i.Discount)
            .HasColumnType("DECIMAL(18,2)")
            .IsRequired();

        builder.Property(i => i.Tax)
            .HasColumnType("DECIMAL(18,2)")
            .IsRequired();

        builder.Property(i => i.DeliveryFee)
            .HasColumnType("DECIMAL(18,2)")
            .IsRequired();

        builder.Property(i => i.Total)
            .HasColumnType("DECIMAL(18,2)")
            .IsRequired();

        //Relationships
        builder.HasOne(i => i.Order)
            .WithOne(o => o.Invoice)
            .HasForeignKey<Invoice>(i => i.OrderId)
            .IsRequired();
    }
}