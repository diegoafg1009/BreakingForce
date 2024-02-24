using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class AddressConfiguration : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        //Table
        builder.ToTable("Addresses");

        //Primary Key
        builder.HasKey(e => e.Id);

        //Properties
        builder.Property(e => e.Id)
            .HasDefaultValueSql("NEWID()")
            .IsRequired();

        builder.Property(e => e.Description)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(e => e.ZipCode)
            .HasMaxLength(10)
            .IsRequired();

        builder.Property(e => e.CreatedAt)
            .HasDefaultValueSql("GETDATE()")
            .IsRequired();

        builder.Property(e => e.UpdatedAt)
            .HasDefaultValueSql("GETDATE()")
            .IsRequired();

        //Relationships
        builder.HasOne(e => e.District)
            .WithMany(d => d.Addresses)
            .HasForeignKey(a => a.DistrictId)
            .IsRequired();

        builder.HasOne(e => e.Customer)
            .WithOne(c => c.Address)
            .HasForeignKey<Customer>(c => c.AddressId)
            .IsRequired();
    }
}