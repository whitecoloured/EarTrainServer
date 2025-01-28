using EarTrain.Core.Enums;
using System;
using System.Collections.Generic;

namespace EarTrain.Core.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ProductsCategory Category { get; set; }

        public ProductBrand Brand { get; set; }
        public Guid? BrandID { get; set; }

        public int Price { get; set; } //price will have ET Coins currency, which are given only for successfully completed trainings.

        public List<KeyValuePair<string, string>> Characteristics { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
        public ICollection<ProductReview> ProductReviews { get; set; }

        public static Product Create(string Name, string Desc, ProductsCategory Category, ProductBrand Brand, int Price, List<KeyValuePair<string,string>> Characteristics)
        {
            return new()
            {
                Name = Name,
                Description = Desc,
                Category = Category,
                Brand = Brand,
                Price = Price,
                Characteristics = Characteristics
            };
        }
    }
}
