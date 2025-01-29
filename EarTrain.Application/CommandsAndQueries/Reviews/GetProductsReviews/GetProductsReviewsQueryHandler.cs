using AutoMapper;
using EarTrain.Application.OtherServices.JWT;
using EarTrain.Core.Models;
using EarTrain.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace EarTrain.Application.CommandsAndQueries.Reviews.GetProductsReviews
{
    public class GetProductsReviewsQueryHandler(ETContext context, IMapper mapper) : IRequestHandler<GetProductsReviewsQuery, List<GetProductsReviewsResponse>>
    {
        private readonly ETContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<List<GetProductsReviewsResponse>> Handle(GetProductsReviewsQuery request, CancellationToken cancellationToken)
        {
            Guid UserID = JwtDataProviderService.GetUserIDFromToken(request.HeaderData);

            var queryableData = _context.ProductReviews
                                .AsNoTracking()
                                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.SortItem))
            {
                Expression<Func<ProductReview, object>> orderKey = request.SortItem switch
                {
                    "mark" => p => p.Mark,
                    _ => p => p.ReviewDate
                };

                queryableData=request.OrderByAsc?
                    queryableData.OrderBy(orderKey):
                    queryableData.OrderByDescending(orderKey);
            }

            var data= await queryableData
                        .Include(p=> p.User)
                        .ToListAsync(cancellationToken);

            var mappedData = _mapper.Map<List<ProductReview>,List<GetProductsReviewsResponse>>(data, opt =>
                opt.AfterMap((src, dest) =>
                {
                    foreach(var (srcReview, destReview) in src.Zip(dest))
                    {
                        destReview.DoesBelongToUser = UserID == srcReview.UserID;
                    }
                }));

            return mappedData;
        }
    }
}
