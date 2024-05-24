using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        //Table
        builder.ToTable("Transactions");

        //Primary Key
        builder.HasKey(t => t.Id);

        //Properties
        builder.Property(t => t.Id)
            .HasDefaultValueSql("UUID()")
            .IsRequired();

        builder.Property(t => t.Date)
            .HasDefaultValueSql("NOW()")
            .IsRequired();

        builder.Property(t => t.UserId);

        //Relationships
        builder.HasOne(t => t.TransactionType)
            .WithMany(tt => tt.Transactions)
            .HasForeignKey(t => t.TransactionTypeId)
            .IsRequired();

        builder.HasMany(t => t.TransactionDetails)
            .WithOne(td => td.Transaction)
            .HasForeignKey(td => td.TransactionId)
            .IsRequired();

        builder.HasOne(t => t.Order)
            .WithOne()
            .HasForeignKey<Transaction>(t => t.OrderId);
    }
}