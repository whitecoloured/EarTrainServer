using MediatR;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;

namespace EarTrain.Application.CommandsAndQueries.Users.EditPassword
{
    public record EditPasswordCommand(PasswordsModel Passwords, KeyValuePair<string, StringValues> HeaderData): IRequest<Unit>;
}
