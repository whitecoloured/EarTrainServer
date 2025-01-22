using Microsoft.EntityFrameworkCore;
using EarTrain.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EarTrain.Infrastructure.Configurations
{
    class ChangedSoundConfig : IEntityTypeConfiguration<ChangedSound>
    {
        public void Configure(EntityTypeBuilder<ChangedSound> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Category)
                .IsRequired();

            builder
                .Property(p => p.SoundSrc)
                .IsRequired();

            builder
                .HasOne(p => p.Task)
                .WithOne(p => p.ChangedSound)
                .HasForeignKey<TrainTask>(p=> p.ChangedSoundID);

            builder
                .Property(p => p.Category)
                .HasConversion<int>();
        }
    }
}
