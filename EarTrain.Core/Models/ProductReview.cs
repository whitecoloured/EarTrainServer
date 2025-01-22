

using System;

namespace EarTrain.Core.Models
{
    public class ProductReview
    {
        public Guid Id { get; set; }
        public string ReviewDesc { get; set; }
        public int Mark {  get; set; }
        public User User { get; set; }
        public Guid? UserID { get; set; }
        public Product Product { get; set; }
        public Guid? ProductID { get; set; }
    }
}
