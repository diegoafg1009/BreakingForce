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
            .HasDefaultValueSql("NEWID()")
            .IsRequired();

        builder.Property(i => i.AssociatedDocument)
            .HasMaxLength(11)
            .IsRequired();

        builder.Property(i => i.SubTotal)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(i => i.Discount)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(i => i.Tax)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(i => i.DeliveryFee)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(i => i.Amount)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        //Relationships
        builder.HasOne(i => i.Order)
            .WithOne(o => o.Invoice)
            .HasForeignKey<Invoice>(i => i.OrderId)
            .IsRequired();
    }
}