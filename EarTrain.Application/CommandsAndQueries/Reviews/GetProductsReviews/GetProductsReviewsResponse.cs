

using System;

namespace EarTrain.Application.CommandsAndQueries.Reviews.GetProductsReviews
{
    public class GetProductsReviewsResponse
    {
        public Guid ID { get; set; }
        public string Login { get; set; }
        public string ReviewDesc {  get; set; }
        public int Mark { get; set;}
        public DateTime ReviewDate { get; set; }
        public bool DoesBelongToUser { get; set; }
    }
}
