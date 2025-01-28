using System;
using System.Collections.Generic;

namespace EarTrain.Application.CommandsAndQueries.Products.GetProducts
{
    public class GetProductsResponse
    {
        public List<RetrievedProduct> Products { get; set; }
        public int TotalProductsAmount { get; set; }
    }
}
