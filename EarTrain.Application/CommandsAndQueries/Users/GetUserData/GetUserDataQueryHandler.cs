using AutoMapper;
using EarTrain.Application.OtherServices.JWT;
using EarTrain.Infrastructure.Context;
using EarTrain.Core.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EarTrain.Application.CommandsAndQueries.Users.GetUserData
{
    public class GetUserDataQueryHandler(ETContext context, IMapper mapper) : IRequestHandler<GetUserDataQuery, GetUserDataResponse>
    {
        private readonly ETContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<GetUserDataResponse> Handle(GetUserDataQuery request, CancellationToken cancellationToken)
        {
            Guid UserID = JwtDataProviderService.GetUserIDFromToken(request.HeaderData);

            if (UserID == Guid.Empty)
                throw new NotFoundException("Ваши данные не были найдены!");

            var data = await _context.Users.FindAsync([UserID],cancellationToken)
                            ?? throw new NotFoundException("Ваши данные не были найдены!");

            var mappedData=_mapper.Map<GetUserDataResponse>(data);

            return mappedData;
        }
    }
}
