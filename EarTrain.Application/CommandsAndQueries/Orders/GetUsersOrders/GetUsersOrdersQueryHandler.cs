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

namespace EarTrain.Application.CommandsAndQueries.Orders.GetUsersOrders
{
    public class GetUsersOrdersQueryHandler(ETContext context, IMapper mapper) : IRequestHandler<GetUsersOrdersQuery, List<GetUsersOrdersResponse>>
    {
        private readonly ETContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<List<GetUsersOrdersResponse>> Handle(GetUsersOrdersQuery request, CancellationToken cancellationToken)
        {
            Guid UserID=JwtDataProviderService.GetUserIDFromToken(request.HeaderData);

            if (UserID==Guid.Empty)
            {
                throw new BadRequestException("Ваши данные не были найдены!");
            }

            var data= await _context.Orders
                                .AsNoTracking()
                                .Include(p=> p.Products)
                                .OrderByDescending(p=> p.OrderDate)
                                .ToListAsync(cancellationToken);

            var mappedData= _mapper.Map<List<GetUsersOrdersResponse>>(data);

            return mappedData;
        }
    }
}
