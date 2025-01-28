using EarTrain.Application.OtherServices;
using EarTrain.Application.OtherServices.JWT;
using EarTrain.Core.Models;
using EarTrain.Core.Exceptions;
using EarTrain.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;

namespace EarTrain.Application.CommandsAndQueries.Users.Register
{
    public class RegisterCommandHandler(ETContext context, IValidator<RegisterCommand> validator, JwtTokenProviderService jwtTokenService) : IRequestHandler<RegisterCommand, TokensResponse>
    {
        private readonly ETContext _context = context;
        private readonly IValidator<RegisterCommand> _validator = validator;
        private readonly JwtTokenProviderService _jwtTokenService = jwtTokenService;

        public async Task<TokensResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {

            var modelState= _validator.Validate(request);

            if (!modelState.IsValid)
            {
                throw new BadRequestException(string.Join('\n', modelState.Errors));
            }

            var hashedPassword =HashService.GetHashedPassword(request.Password);
            if (await _context.Users.AnyAsync(p=> p.Email==request.Email || p.Login==request.Password || p.Password==hashedPassword, cancellationToken))
            {
                throw new Exception("Такие данные установить нельзя!");
            }

            User user = User.Create(request.Login, request.Email, hashedPassword, request.Address);

            await _context.Users.AddAsync(user, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            var addedUser = await _context.Users.FirstOrDefaultAsync(p => p.Email == request.Email, cancellationToken) ?? throw new NotFoundException("Ваши данные не были найдены!");

            string accessToken = _jwtTokenService.GenereateJWTAccessToken(addedUser.Id, addedUser.Role);
            string refreshToken = _jwtTokenService.GenerateJWTRefreshToken(addedUser.Id, addedUser.Role);

            return new(accessToken, refreshToken);
        }
    }
}
