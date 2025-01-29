using System.Collections.Generic;

namespace EarTrain.Application.CommandsAndQueries.Products.GetProductInfo
{
    public class GetProductInfoResponse
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string BrandName { get; set; }
        public int Price { get; set; }
        public List<KeyValuePair<string, string>> Characteristics { get; set; }
    }
}
