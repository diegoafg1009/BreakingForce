using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class DistrictConfiguration : IEntityTypeConfiguration<District>
{
    public void Configure(EntityTypeBuilder<District> builder)
    {
        //Table
        builder.ToTable("Districts");

        //Primary Key
        builder.HasKey(d => d.Id);

        //Properties
        builder.Property(d => d.Id)
            .HasDefaultValueSql("UUID()")
            .IsRequired();

        builder.Property(d => d.Name)
            .HasMaxLength(100)
            .IsRequired();

        //Relationships
        builder.HasOne(d => d.Province)
            .WithMany(p => p.Districts)
            .HasForeignKey(d => d.ProvinceId)
            .IsRequired();

        builder.HasMany(d => d.Addresses)
            .WithOne(a => a.District)
            .HasForeignKey(a => a.DistrictId);
    }
}