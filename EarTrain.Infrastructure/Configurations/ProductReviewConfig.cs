using EarTrain.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EarTrain.Infrastructure.Configurations
{
    public class ProductReviewConfig : IEntityTypeConfiguration<ProductReview>
    {
        public void Configure(EntityTypeBuilder<ProductReview> builder)
        {
            builder
                .HasKey(p=> p.Id);

            builder
                .Property(p => p.ReviewDesc)
                .IsRequired();

            builder
                .Property(p => p.Mark)
                .IsRequired();

            builder
                .HasOne(p => p.User)
                .WithMany(p=> p.ProductReviews)
                .HasForeignKey(p=> p.UserID);

            builder
                .HasOne(p => p.Product)
                .WithMany(p=> p.ProductReviews)
                .HasForeignKey(p=> p.ProductID);
        }
    }
}
