using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class EnterpriseDataConfiguration : IEntityTypeConfiguration<EnterpriseData>
{
    public void Configure(EntityTypeBuilder<EnterpriseData> builder)
    {
        //Table
        builder.ToTable("EnterpriseData");

        //Primary Key
        builder.HasKey(ed => ed.Id);

        //Properties
        builder.Property(ed => ed.Id)
            .HasDefaultValueSql("UUID()")
            .IsRequired();

        builder.Property(ed => ed.BusinessName)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(ed => ed.Ruc)
            .HasMaxLength(11)
            .IsRequired();

        //Relationships
        builder.HasOne(ed => ed.Customer)
            .WithOne(c => c.EnterpriseData)
            .HasForeignKey<EnterpriseData>(ed => ed.CustomerId)
            .IsRequired();
    }
}