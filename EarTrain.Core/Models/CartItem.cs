using System;

namespace EarTrain.Core.Models
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public Product Product { get; set; }
        public Guid? ProductID { get; set; }
        public User User { get; set; }
        public Guid? UserID { get; set; }
    }
}
