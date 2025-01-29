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

namespace EarTrain.Application.CommandsAndQueries.Cart.GetUsersCart
{
    public class GetUsersCartQueryHandler(ETContext context, IMapper mapper) : IRequestHandler<GetUsersCartQuery, List<GetUsersCartResponse>>
    {
        private readonly ETContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<List<GetUsersCartResponse>> Handle(GetUsersCartQuery request, CancellationToken cancellationToken)
        {
            Guid UserID = JwtDataProviderService.GetUserIDFromToken(request.HeaderData);

            if (UserID==Guid.Empty)
            {
                throw new BadRequestException("Ваши данные не найдены!");
            }

            var data= await _context.Cart
                                .AsNoTracking()
                                .Include(p=> p.Product)
                                .Where(p=> p.UserID==UserID)
                                .ToListAsync(cancellationToken);

            var mappedData= _mapper.Map<List<GetUsersCartResponse>>(data);

            return mappedData;
        }
    }
}
