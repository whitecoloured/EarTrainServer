using System;

namespace EarTrain.Application.CommandsAndQueries.Products.GetProducts
{
    public class RetrievedProduct
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; }
        public string BrandName { get; set; }
        public int Price { get; set; }
    }
}
