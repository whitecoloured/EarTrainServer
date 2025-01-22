using Microsoft.EntityFrameworkCore;
using EarTrain.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EarTrain.Infrastructure.Configurations
{
    class TaskConfig : IEntityTypeConfiguration<TrainTask>
    {
        public void Configure(EntityTypeBuilder<TrainTask> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Category)
                .IsRequired();

            builder
                .Property(p=> p.Answer)
                .IsRequired();

            builder
                .HasOne(p => p.ChangedSound)
                .WithOne(p => p.Task)
                .HasForeignKey<ChangedSound>(p=> p.TaskID);

            builder
                .HasOne(p => p.OGSound)
                .WithMany(p => p.Tasks);

            builder
                .Property(p => p.Category)
                .HasConversion<int>();

        }
    }
}
