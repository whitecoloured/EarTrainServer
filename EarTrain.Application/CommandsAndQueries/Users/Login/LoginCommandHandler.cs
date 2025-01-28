using EarTrain.Infrastructure.Context;
using EarTrain.Core.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using EarTrain.Application.OtherServices;
using EarTrain.Application.OtherServices.JWT;

namespace EarTrain.Application.CommandsAndQueries.Users.Login
{
    public class LoginCommandHandler(ETContext context, JwtTokenProviderService jwtTokenProvider) : IRequestHandler<LoginCommand, TokensResponse>
    {
        private readonly ETContext _context = context;
        private readonly JwtTokenProviderService _jwtTokenProvider = jwtTokenProvider;

        public async Task<TokensResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(p => p.Email == request.Input || p.Login == request.Input, cancellationToken) ?? throw new NotFoundException("Пользователь с этими данными был не найден!");

            string hashedPassword=HashService.GetHashedPassword(request.Password);

            if (user.Password != hashedPassword)
            {
                throw new BadRequestException("Неверный пароль!");
            }

            string accessToken = _jwtTokenProvider.GenereateJWTAccessToken(user.Id, user.Role);
            string refreshToken = _jwtTokenProvider.GenerateJWTRefreshToken(user.Id, user.Role);

            return new(accessToken, refreshToken);
        }
    }
}
