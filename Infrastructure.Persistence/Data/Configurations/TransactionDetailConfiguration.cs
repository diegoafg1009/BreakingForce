using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class TransactionDetailConfiguration : IEntityTypeConfiguration<TransactionDetail>
{
    public void Configure(EntityTypeBuilder<TransactionDetail> builder)
    {
        //Table
        builder.ToTable("TransactionDetails");

        //Primary Key
        builder.HasKey(td => new { td.TransactionId, td.InventoryId});

        //Properties

        builder.Property(td => td.AmountAffected)
            .IsRequired();

        //Relationships
        builder.HasOne(td => td.Inventory)
            .WithMany(p => p.TransactionDetails)
            .HasForeignKey(td => td.InventoryId)
            .IsRequired();

        builder.HasOne(td => td.Transaction)
            .WithMany(t => t.TransactionDetails)
            .HasForeignKey(td => td.TransactionId)
            .IsRequired();
    }
}