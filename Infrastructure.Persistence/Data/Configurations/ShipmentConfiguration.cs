using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class ShipmentConfiguration : IEntityTypeConfiguration<Shipment>
{
    public void Configure(EntityTypeBuilder<Shipment> builder)
    {
        //Table
        builder.ToTable("Shipments");

        //Primary Key
        builder.HasKey(s => s.Id);

        //Properties
        builder.Property(s => s.Id)
            .HasDefaultValueSql("NEWID()")
            .IsRequired();


        builder.Property(s => s.Address)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(s => s.Reference)
            .HasMaxLength(200);

        //Relationships
        builder.HasOne(s => s.District)
            .WithMany()
            .HasForeignKey(s => s.DistrictId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder.HasOne(s => s.Province)
            .WithMany()
            .HasForeignKey(s => s.ProvinceId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder.HasOne(s => s.Department)
            .WithMany()
            .HasForeignKey(s => s.DepartmentId)
            .OnDelete(DeleteBehavior.NoAction)
            .IsRequired();

        builder.HasOne(s => s.Order)
            .WithOne(o => o.Shipment)
            .HasForeignKey<Order>(o => o.ShipmentId)
            .IsRequired();
    }
}