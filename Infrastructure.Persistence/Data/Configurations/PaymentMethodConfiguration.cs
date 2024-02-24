using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class PaymentMethodConfiguration : IEntityTypeConfiguration<PaymentMethod>
{
    public void Configure(EntityTypeBuilder<PaymentMethod> builder)
    {
        //Table
        builder.ToTable("PaymentMethods");

        //Primary Key
        builder.HasKey(pm => pm.Id);

        //Properties
        builder.Property(pm => pm.Id)
            .HasDefaultValueSql("NEWID()")
            .IsRequired();

        builder.Property(pm => pm.Name)
            .HasMaxLength(50)
            .IsRequired();

        //Relationships
        builder.HasMany(pm => pm.Orders)
            .WithOne(o => o.PaymentMethod)
            .HasForeignKey(o => o.PaymentMethodId)
            .IsRequired();
    }
}