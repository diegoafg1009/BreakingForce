using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class DeliveryMethodConfiguration : IEntityTypeConfiguration<DeliveryMethod>
{
    public void Configure(EntityTypeBuilder<DeliveryMethod> builder)
    {
        //Table
        builder.ToTable("DeliveryMethods");

        //Primary Key
        builder.HasKey(dm => dm.Id);

        //Properties
        builder.Property(dm => dm.Id)
            .HasDefaultValueSql("NEWID()")
            .IsRequired();

        builder.Property(dm => dm.Name)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(dm => dm.Price)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        //Relationships
        builder.HasMany(dm => dm.Shipments)
            .WithOne(s => s.DeliveryMethod)
            .HasForeignKey(s => s.DeliveryMethodId)
            .IsRequired();
    }
}