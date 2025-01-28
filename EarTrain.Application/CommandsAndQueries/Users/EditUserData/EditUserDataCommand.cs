using MediatR;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;

namespace EarTrain.Application.CommandsAndQueries.Users.EditUserData
{
    public record EditUserDataCommand(EditUserModel UserModel, KeyValuePair<string, StringValues> HeaderData) : IRequest<Unit>;
}
