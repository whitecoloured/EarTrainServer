using EarTrain.Infrastructure.Configurations;
using EarTrain.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EarTrain.Infrastructure.Context
{
    public class ETContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<TrainTask> Tasks { get; set; }
        public DbSet<Sound> Sounds { get; set; }
        public DbSet<ChangedSound> ChangedSounds { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductReview> ProductReviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CartItem> Cart { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new TaskConfig());
            modelBuilder.ApplyConfiguration(new SoundConfig());
            modelBuilder.ApplyConfiguration(new ChangedSoundConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new OrderConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new ProductBrandConfig());
            modelBuilder.ApplyConfiguration(new ProductReviewConfig());
            modelBuilder.ApplyConfiguration(new CartItemConfig());
        }
    }
}
