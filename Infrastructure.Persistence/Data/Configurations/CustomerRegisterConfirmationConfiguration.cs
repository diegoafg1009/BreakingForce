using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class CustomerRegisterConfirmationConfiguration : IEntityTypeConfiguration<CustomerRegisterConfirmation>
{
    public void Configure(EntityTypeBuilder<CustomerRegisterConfirmation> builder)
    {
        //Table
        builder.ToTable("CustomerRegisterConfirmations");

        //Primary Key
        builder.HasKey(crc => crc.Id);

        //Properties
        builder.Property(crc => crc.Id)
            .HasDefaultValueSql("UUID()")
            .IsRequired();

        builder.Property(crc => crc.Token)
            .IsRequired();

        builder.Property(crc => crc.ExpirationDate)
            .IsRequired();

        builder.Property(crc => crc.CustomerId)
            .IsRequired();

        //Relationships
        builder.HasOne(crc => crc.Customer)
            .WithOne(c => c.CustomerRegisterConfirmation!)
            .HasForeignKey<CustomerRegisterConfirmation>(crc => crc.CustomerId);
    }
}