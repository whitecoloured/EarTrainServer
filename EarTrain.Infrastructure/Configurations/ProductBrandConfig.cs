using EarTrain.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EarTrain.Infrastructure.Configurations
{
    public class ProductBrandConfig : IEntityTypeConfiguration<ProductBrand>
    {
        public void Configure(EntityTypeBuilder<ProductBrand> builder)
        {
            builder
                .HasKey(p => p.ID);

            builder
                .Property(p => p.Name)
                .IsRequired();

            builder
                .HasMany(p => p.Products)
                .WithOne(p => p.Brand)
                .HasForeignKey(p => p.BrandID);
        }
    }
}
