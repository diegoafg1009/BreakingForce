using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        //Table
        builder.ToTable("Customers");

        //Primary Key
        builder.HasKey(c => c.Id);

        //Properties
        builder.Property(c => c.Id)
            .HasDefaultValueSql("UUID()")
            .IsRequired();

        builder.Property(c => c.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.Surname)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(c => c.Email)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(c => c.Phone)
            .HasMaxLength(9)
            .IsRequired();

        builder.Property(c => c.CreatedAt)
            .HasDefaultValueSql("NOW()")
            .IsRequired();

        builder.Property(c => c.UpdatedAt)
            .HasDefaultValueSql("NOW()")
            .IsRequired();

        //Relationships
        builder.HasOne(c => c.EnterpriseData)
            .WithOne(ed => ed.Customer)
            .HasForeignKey<Customer>(c => c.EnterpriseDataId);
        
        builder.HasMany(c => c.Orders)
            .WithOne(o => o.Customer)
            .HasForeignKey(o => o.CustomerId);

        builder.HasOne(c => c.Address)
            .WithOne(a => a.Customer)
            .HasForeignKey<Address>(a => a.CustomerId);

        builder.HasOne(c => c.Identification)
            .WithOne(i => i.Customer)
            .HasForeignKey<Identification>(i => i.CustomerId)
            .IsRequired();
    }
}