using Domain.Entities;
using Infrastructure.Persistence.Data.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class TransactionTypeConfiguration : IEntityTypeConfiguration<TransactionType>
{
    public void Configure(EntityTypeBuilder<TransactionType> builder)
    {
        //Table
        builder.ToTable("TransactionTypes");

        //Primary Key
        builder.HasKey(tt => tt.Id);

        //Properties
        builder.Property(tt => tt.Id)
            .HasDefaultValueSql("UUID()")
            .IsRequired();

        builder.Property(tt => tt.Name)
            .HasMaxLength(150)
            .IsRequired();

        //Relationships
        builder.HasMany(tt => tt.Transactions)
            .WithOne(t => t.TransactionType)
            .HasForeignKey(t => t.TransactionTypeId)
            .IsRequired();

        //Seed Data
        builder.HasData(DefaultTransactionTypes.Seed());
    }
}