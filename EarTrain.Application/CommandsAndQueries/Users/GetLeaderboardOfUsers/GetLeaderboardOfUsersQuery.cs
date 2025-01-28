
using MediatR;
using System.Collections.Generic;

namespace EarTrain.Application.CommandsAndQueries.Users.GetLeaderboardOfUsers
{
    public record GetLeaderboardOfUsersQuery() : IRequest<List<GetLeaderboardOfUsersResponse>>;
}
