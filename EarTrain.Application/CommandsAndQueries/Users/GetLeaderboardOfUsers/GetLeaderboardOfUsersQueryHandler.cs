
using AutoMapper;
using EarTrain.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EarTrain.Application.CommandsAndQueries.Users.GetLeaderboardOfUsers
{
    public class GetLeaderboardOfUsersQueryHandler(ETContext context, IMapper mapper) : IRequestHandler<GetLeaderboardOfUsersQuery, List<GetLeaderboardOfUsersResponse>>
    {
        private readonly ETContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<List<GetLeaderboardOfUsersResponse>> Handle(GetLeaderboardOfUsersQuery request, CancellationToken cancellationToken)
        {
            var data = await _context.Users
                                .AsNoTracking()
                                .OrderByDescending(p=> p.SuccessfullyCompletedTrainingsAmount)
                                .Take(3)
                                .ToListAsync(cancellationToken);

            var mappedData=_mapper.Map<List<GetLeaderboardOfUsersResponse>>(data);

            return mappedData;
        }
    }
}
