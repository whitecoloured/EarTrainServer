using Microsoft.EntityFrameworkCore;
using EarTrain.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EarTrain.Infrastructure.Configurations
{
    class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Login)
                .IsRequired();

            builder
                .Property(p => p.Password)
                .IsRequired();

            builder
                .Property(p => p.Email)
                .IsRequired();

            builder
                .Property(p => p.Role)
                .HasConversion<int>();

            builder
                .Property(p => p.ETCoinsAmount)
                .HasDefaultValue(0);

            builder
                .Property(p=> p.TrainingsCompletedAmount)
                .HasDefaultValue(0);

            builder
                .Property(p=> p.SuccessfullyCompletedTrainingsAmount)
                .HasDefaultValue(0);

            builder
                .HasMany(p => p.Orders)
                .WithOne(p => p.Customer);

            builder
                .HasMany(p=> p.CartItems)
                .WithOne(p=> p.User)
                .HasForeignKey(p=> p.UserID);

            builder
                .OwnsOne(p => p.Address, address=>
                {
                    address.Property(p => p.StreetType)
                        .HasColumnName("StreetType")
                        .HasConversion<string>()
                        .IsRequired();

                    address.Property(p => p.StreetName)
                        .HasColumnName("StreetName")
                        .IsRequired();

                    address.Property(p=> p.StreetNumber)
                        .HasColumnName("StreetNumber")
                        .IsRequired();
                }
                );
        }
    }
}
