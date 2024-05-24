using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        //Table
        builder.ToTable("Departments");

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
        builder.HasMany(d => d.Provinces)
            .WithOne(p => p.Department)
            .HasForeignKey(p => p.DepartmentId);
    }
}