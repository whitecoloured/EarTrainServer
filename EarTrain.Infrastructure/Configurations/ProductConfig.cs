using Microsoft.EntityFrameworkCore;
using EarTrain.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq;
using System;

namespace EarTrain.Infrastructure.Configurations
{
    class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Name)
                .IsRequired();

            builder
                .Property(p => p.Description)
                .IsRequired();

            builder
                .Property(p => p.Category)
                .IsRequired()
                .HasConversion<int>();


            builder
                .Property(p => p.Price)
                .IsRequired();

            builder
                .Property(p=> p.Characteristics)
                .IsRequired();

            builder
                .Property(p => p.Characteristics)
                .HasConversion(
                    data=> JsonConvert.SerializeObject(data),
                    data=> JsonConvert.DeserializeObject<List<KeyValuePair<string,string>>>(data),
                    new ValueComparer<List<KeyValuePair<string, string>>>(
                        (f,n)=> f.SequenceEqual(n),
                        list=> list.Aggregate(0, (f,n)=> HashCode.Combine(f, n.GetHashCode())),
                        list=> list.ToList()
                    )
                );

            builder
                .HasMany(p => p.Orders)
                .WithMany(p => p.Products);

            builder
                .HasMany(p => p.CartItems)
                .WithOne(p => p.Product);
        }
    }
}
