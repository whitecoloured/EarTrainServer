using System;

namespace EarTrain.Application.CommandsAndQueries.Reviews.GetUsersReviews
{
    public class GetUsersReviewsResponse
    {
        public Guid ID { get; set; }
        public string ProductName { get; set; }
        public string ReviewDesc { get; set; }
        public int Mark { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
