using EarTrain.Application.OtherServices.JWT;
using EarTrain.Core.Exceptions;
using EarTrain.Infrastructure.Context;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EarTrain.Application.CommandsAndQueries.Users.EditUserData
{
    public class EditUserDataCommandHandler(ETContext context, IValidator<EditUserModel> validator) : IRequestHandler<EditUserDataCommand, Unit>
    {
        private readonly ETContext _context = context;
        private readonly IValidator<EditUserModel> _validator = validator;

        public async Task<Unit> Handle(EditUserDataCommand request, CancellationToken cancellationToken)
        {
            var modelState= _validator.Validate(request.UserModel);

            if (!modelState.IsValid)
            {
                throw new BadRequestException(string.Join('\n', modelState.Errors));
            }

            Guid UserID = JwtDataProviderService.GetUserIDFromToken(request.HeaderData);

            if (UserID == Guid.Empty)
                throw new NotFoundException("Ваши данные не были найдены!");

            if (await _context.Users.AnyAsync(p => (p.Login == request.UserModel.Login || p.Email == request.UserModel.Email) && p.Id!=UserID,cancellationToken))
                throw new BadRequestException("Такие данные уже существуют!");

            await _context.Users
                    .Where(p => p.Id == UserID)
                    .ExecuteUpdateAsync(opt =>
                        opt
                        .SetProperty(p => p.Email, request.UserModel.Email)
                        .SetProperty(p => p.Login, request.UserModel.Login)
                        .SetProperty(p => p.Address, request.UserModel.Address),
                        cancellationToken
                        );

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        }
    }
}
