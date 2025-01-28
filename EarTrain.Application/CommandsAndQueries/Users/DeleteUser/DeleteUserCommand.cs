using MediatR;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;

namespace EarTrain.Application.CommandsAndQueries.Users.DeleteUser
{
    public record DeleteUserCommand(KeyValuePair<string, StringValues> HeaderData) : IRequest<Unit>;
}
