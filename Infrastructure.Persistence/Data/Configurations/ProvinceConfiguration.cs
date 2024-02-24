using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class ProvinceConfiguration : IEntityTypeConfiguration<Province>
{
    public void Configure(EntityTypeBuilder<Province> builder)
    {
        //Table
        builder.ToTable("Provinces");

        //Primary Key
        builder.HasKey(p => p.Id);

        //Properties
        builder.Property(p => p.Id)
            .HasDefaultValueSql("NEWID()")
            .IsRequired();

        builder.Property(p => p.Name)
            .HasMaxLength(50)
            .IsRequired();

        //Relationships
        builder.HasOne(p => p.Department)
            .WithMany(d => d.Provinces)
            .HasForeignKey(p => p.DepartmentId)
            .IsRequired();

        builder.HasMany(p => p.Districts)
            .WithOne(d => d.Province)
            .HasForeignKey(c => c.ProvinceId)
            .IsRequired();
    }
}