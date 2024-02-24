using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class ProductObjectiveConfiguration : IEntityTypeConfiguration<ProductObjective>
{
    public void Configure(EntityTypeBuilder<ProductObjective> builder)
    {
        //Table
        builder.ToTable("ProductObjectives");

        //Primary Key
        builder.HasKey(po => po.Id);

        //Properties
        builder.Property(po => po.Id)
            .HasDefaultValueSql("NEWID()")
            .IsRequired();

        builder.Property(po => po.Name)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(po => po.Description)
            .HasMaxLength(500);

        //Relationships
        builder.HasMany(po => po.Products)
            .WithOne(p => p.Objective)
            .HasForeignKey(p => p.ObjectiveId)
            .IsRequired();
    }
}