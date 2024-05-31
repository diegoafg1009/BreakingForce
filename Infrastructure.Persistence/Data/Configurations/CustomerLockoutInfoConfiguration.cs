using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class CustomerLockoutInfoConfiguration : IEntityTypeConfiguration<CustomerLockoutInfo>
{
    public void Configure(EntityTypeBuilder<CustomerLockoutInfo> builder)
    {
        //Table
        builder.ToTable("CustomerLockoutInfos");

        //Primary Key
        builder.HasKey(cli => cli.Id);

        //Properties
        builder.Property(cli => cli.Id)
            .HasDefaultValueSql("UUID()")
            .IsRequired();

        builder.Property(cli => cli.AccessFailedCount)
            .IsRequired();

        builder.Property(cli => cli.LockoutEnd)
            .IsRequired(false);

        builder.Property(cli => cli.CustomerId)
            .IsRequired();

        //Relationships
        builder.HasOne(cli => cli.Customer)
            .WithOne(c => c.CustomerLockoutInfo!)
            .HasForeignKey<CustomerLockoutInfo>(cli => cli.CustomerId);
    }
}