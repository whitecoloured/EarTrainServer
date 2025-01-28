using EarTrain.Application.OtherServices;
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

namespace EarTrain.Application.CommandsAndQueries.Users.EditPassword
{
    public class EditPasswordCommandHandler(ETContext context, IValidator<PasswordsModel> validator) : IRequestHandler<EditPasswordCommand, Unit>
    {
        private readonly ETContext _context = context;
        private readonly IValidator<PasswordsModel> _validator = validator;

        public async Task<Unit> Handle(EditPasswordCommand request, CancellationToken cancellationToken)
        {
            var modelState=_validator.Validate(request.Passwords);

            if (!modelState.IsValid)
            {
                throw new BadRequestException(string.Join('\n',modelState.Errors));
            }

            Guid UserID = JwtDataProviderService.GetUserIDFromToken(request.HeaderData);

            if (UserID == Guid.Empty)
                throw new NotFoundException("Ваши данные не были найдены!");

            string hashedOldPassword = HashService.GetHashedPassword(request.Passwords.OldPassword);

            if (!await _context.Users.AnyAsync(p=> p.Password==hashedOldPassword && p.Id==UserID, cancellationToken))
                throw new BadRequestException("Ваш старый пароль неверный!");

            string hashedNewPassword = HashService.GetHashedPassword(request.Passwords.NewPassword);

            if (await _context.Users.AnyAsync(p => p.Password == hashedNewPassword,cancellationToken))
                throw new BadRequestException("Такой пароль установить нельзя!");

            await _context.Users
                    .Where(p => p.Id == UserID)
                    .ExecuteUpdateAsync(opt =>
                        opt.SetProperty(p=> p.Password,hashedNewPassword),
                        cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
