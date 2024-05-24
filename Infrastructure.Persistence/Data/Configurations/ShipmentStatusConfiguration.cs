using Domain.Entities;
using Infrastructure.Persistence.Data.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class ShipmentStatusConfiguration : IEntityTypeConfiguration<ShipmentStatus>
{
    public void Configure(EntityTypeBuilder<ShipmentStatus> builder)
    {
        //Table
        builder.ToTable("ShipmentStatuses");

        //Primary Key
        builder.HasKey(ss => ss.Id);

        //Properties
        builder.Property(ss => ss.Id)
            .HasDefaultValueSql("UUID()")
            .IsRequired();

        builder.Property(ss => ss.Name)
            .HasMaxLength(50)
            .IsRequired();

        //Relationships
        builder.HasMany(ss => ss.Shipments)
            .WithOne(s => s.ShipmentStatus)
            .HasForeignKey(s => s.ShipmentStatusId)
            .IsRequired();

        //Seed Data
        builder.HasData(DefaultShipmentStatuses.Seed());
    }
}