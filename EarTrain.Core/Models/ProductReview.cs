

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

        public static ProductReview Create(string ReviewDesc, int Mark, User User, Product Product)
        {
            return new()
            {
                ReviewDesc = ReviewDesc,
                User = User,
                Product = Product,
                Mark = Mark
            };
        }
    }
}
