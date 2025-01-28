using MediatR;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;

namespace EarTrain.Application.CommandsAndQueries.Users.UpdateUsersCredits
{
    public record UpdateUsersCreditsCommand(KeyValuePair<string, StringValues> HeaderData, bool IsSuccesfullyCompleted) :IRequest<Unit>;
}
