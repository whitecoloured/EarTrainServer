using System;
using System.Collections.Generic;

namespace EarTrain.Application.CommandsAndQueries.Orders.GetUsersOrders
{
    public class GetUsersOrdersResponse
    {
        public Guid ID { get; set; }
        public List<OrderedProduct> OrderedProducts { get; set; }
        public int TotalPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime OrderReceived { get; set; }
    }
}
