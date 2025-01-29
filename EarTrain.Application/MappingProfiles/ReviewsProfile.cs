using AutoMapper;
using EarTrain.Application.CommandsAndQueries.Reviews.GetProductsReviews;
using EarTrain.Application.CommandsAndQueries.Reviews.GetUsersReviews;
using EarTrain.Core.Models;

namespace EarTrain.Application.MappingProfiles
{
    public class ReviewsProfile : Profile
    {
        public ReviewsProfile()
        {
            CreateMap<ProductReview, GetProductsReviewsResponse>()
                .ForMember(p => p.ID, opt => opt.MapFrom(p => p.Id))
                .ForMember(p => p.Login, opt => opt.MapFrom(p => p.User.Login))
                .ForMember(p => p.ReviewDesc, opt => opt.MapFrom(p => p.ReviewDesc))
                .ForMember(p => p.Mark, opt => opt.MapFrom(p => p.Mark))
                .ForMember(p=> p.ReviewDate, opt=> opt.MapFrom(p=> p.ReviewDesc))
                .ForMember(p=> p.DoesBelongToUser, opt=> opt.Ignore());

            CreateMap<ProductReview, GetUsersReviewsResponse>()
                .ForMember(p => p.ID, opt => opt.MapFrom(p => p.Id))
                .ForMember(p => p.ProductName, opt => opt.MapFrom(p => p.Product.Name))
                .ForMember(p => p.ReviewDesc, opt => opt.MapFrom(p => p.ReviewDesc))
                .ForMember(p => p.Mark, opt => opt.MapFrom(p => p.Mark))
                .ForMember(p => p.ReviewDate, opt => opt.MapFrom(p => p.ReviewDate));
        }
    }
}
