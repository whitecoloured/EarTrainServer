using Microsoft.EntityFrameworkCore;
using EarTrain.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EarTrain.Infrastructure.Configurations
{
    class SoundConfig : IEntityTypeConfiguration<Sound>
    {
        public void Configure(EntityTypeBuilder<Sound> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Category)
                .IsRequired();

            builder
                .Property(p=> p.SoundSrc)
                .IsRequired();

            builder
                .HasMany(p => p.Tasks)
                .WithOne(p => p.OGSound)
                .HasForeignKey(p=> p.OGSoundID);

            builder
                .Property(p => p.Category)
                .HasConversion<int>();
        }
    }
}
