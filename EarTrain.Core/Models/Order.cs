using System;
using System.Collections.Generic;

namespace EarTrain.Core.Models
{
    public class Order
    {
        private static readonly Random rand = new();
        public Guid Id { get; set; }
        public ICollection<Product> Products { get; set; }
        public User Customer { get; set; }
        public Guid? CustomerID { get; set; }
        public DateTime OrderDate { get; private set; }
        public DateTime OrderReceived { get; private set; }

        public Order()
        {
            OrderDate = DateTime.Now;
            OrderReceived = DateTime.Now.AddDays(rand.Next(5,8));
        }

        public static Order Create(User User, ICollection<Product> Products)
        {
            return new()
            {
                Customer = User,
                Products = Products
            };
        }
    }
}
