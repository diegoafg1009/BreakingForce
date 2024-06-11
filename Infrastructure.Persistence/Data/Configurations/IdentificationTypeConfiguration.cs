using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class IdentificationTypeConfiguration : IEntityTypeConfiguration<IdentificationType>
{
    public void Configure(EntityTypeBuilder<IdentificationType> builder)
    {
        //Table
        builder.ToTable("IdentificationTypes");

        //Primary Key
        builder.HasKey(it => it.Id);

        //Properties
        builder.Property(it => it.Id)
            .HasDefaultValueSql("UUID()")
            .IsRequired();

        builder.Property(it => it.Name)
            .HasMaxLength(100)
            .IsRequired();

        //Relationships
        builder.HasMany(it => it.Identifications)
            .WithOne(i => i.IdentificationType)
            .HasForeignKey(i => i.IdentificationTypeId);

        builder.HasMany<Invoice>()
            .WithOne()
            .HasForeignKey(i => i.IdentificationTypeId)
            .IsRequired();
    }
}