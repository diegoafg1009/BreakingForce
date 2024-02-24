using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class IdentificationConfiguration : IEntityTypeConfiguration<Identification>
{
    public void Configure(EntityTypeBuilder<Identification> builder)
    {
        //Table
        builder.ToTable("Identifications");

        //Primary Key
        builder.HasKey(i => i.Id);

        //Properties
        builder.Property(i => i.Id)
            .HasDefaultValueSql("NEWID()")
            .IsRequired();

        builder.Property(i => i.Number)
            .HasMaxLength(20)
            .IsRequired();

        //Relationships
        builder.HasOne(i => i.Customer)
            .WithOne(c => c.Identification)
            .HasForeignKey<Customer>(c => c.IdentificationId)
            .IsRequired();

        builder.HasOne(i => i.IdentificationType)
            .WithMany(it => it.Identifications)
            .HasForeignKey(i => i.IdentificationTypeId);
    }
}