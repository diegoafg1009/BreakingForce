using Domain.Entities;
using Infrastructure.Persistence.Data.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Data.Configurations;

public class OrderStatusConfiguration : IEntityTypeConfiguration<OrderStatus>
{
    public void Configure(EntityTypeBuilder<OrderStatus> builder)
    {
        //Table
        builder.ToTable("OrderStatuses");

        //Primary Key
        builder.HasKey(os => os.Id);

        //Properties
        builder.Property(os => os.Id)
            .HasDefaultValueSql("NEWID()")
            .IsRequired();

        builder.Property(os => os.Name)
            .HasMaxLength(50)
            .IsRequired();

        //Relationships
        builder.HasMany(os => os.Orders)
            .WithOne(o => o.OrderStatus)
            .HasForeignKey(o => o.OrderStatusId)
            .IsRequired();

        //Seed Data
        builder.HasData(DefaultOrderStatuses.Seed());
    }
}