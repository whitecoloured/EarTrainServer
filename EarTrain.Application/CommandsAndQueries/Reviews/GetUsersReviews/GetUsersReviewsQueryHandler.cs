

using AutoMapper;
using EarTrain.Application.OtherServices.JWT;
using EarTrain.Core.Exceptions;
using EarTrain.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EarTrain.Application.CommandsAndQueries.Reviews.GetUsersReviews
{
    public class GetUsersReviewsQueryHandler(ETContext context, IMapper mapper) : IRequestHandler<GetUsersReviewsQuery, List<GetUsersReviewsResponse>>
    {
        private readonly ETContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<List<GetUsersReviewsResponse>> Handle(GetUsersReviewsQuery request, CancellationToken cancellationToken)
        {
            Guid UserID = JwtDataProviderService.GetUserIDFromToken(request.HeaderData);

            if (UserID==Guid.Empty)
            {
                throw new BadRequestException("Ваши данные не найдены!");
            }

            var data= await _context.ProductReviews
                                .AsNoTracking()
                                .Include(p=> p.Product)
                                .Where(p=> p.UserID==UserID)
                                .ToListAsync(cancellationToken);

            var mappedData=_mapper.Map<List<GetUsersReviewsResponse>>(data);

            return mappedData;
        }
    }
}
