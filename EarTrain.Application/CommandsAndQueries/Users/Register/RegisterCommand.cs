using EarTrain.Core.Models;
using MediatR;

namespace EarTrain.Application.CommandsAndQueries.Users.Register
{
    public record RegisterCommand(string Login, string Email, string Password, Address Address) : IRequest<TokensResponse>;
}
