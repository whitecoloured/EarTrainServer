using MediatR;

namespace EarTrain.Application.CommandsAndQueries.Users.Login
{
    public record LoginCommand(string Input, string Password) : IRequest<TokensResponse>;
}
