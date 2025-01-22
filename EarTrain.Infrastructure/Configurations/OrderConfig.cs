using Microsoft.EntityFrameworkCore;
using EarTrain.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EarTrain.Infrastructure.Configurations
{
    class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.OrderDate)
                .IsRequired();

            builder
                .Property(p=> p.OrderReceived)
                .IsRequired();

            builder
                .HasMany(p => p.Products)
                .WithMany(p => p.Orders);

            builder
                .HasOne(p => p.Customer)
                .WithMany(p => p.Orders)
                .HasForeignKey(p => p.CustomerID);
        }
    }
}
