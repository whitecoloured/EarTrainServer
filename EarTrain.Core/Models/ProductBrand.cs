using System;
using System.Collections.Generic;

namespace EarTrain.Core.Models
{
    public class ProductBrand
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }

        public static ProductBrand Create(string Name)
        {
            return new()
            {
                Name = Name
            };
        }
    }
}
