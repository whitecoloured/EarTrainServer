

using System;

namespace EarTrain.Application.CommandsAndQueries.Cart.GetUsersCart
{
    public class GetUsersCartResponse
    {
        public Guid ID { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
    }
}
