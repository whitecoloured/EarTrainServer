using EarTrain.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EarTrain.Infrastructure.Configurations
{
    public class CartItemConfig : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasOne(p => p.User)
                .WithMany(p => p.CartItems)
                .HasForeignKey(p => p.UserID);

            builder
                .HasOne(p=> p.Product)
                .WithMany(p=> p.CartItems)
                .HasForeignKey(p=> p.ProductID);
        }
    }
}
