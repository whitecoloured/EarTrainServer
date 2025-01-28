

using EarTrain.Application.OtherServices.JWT;
using EarTrain.Core.Exceptions;
using EarTrain.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EarTrain.Application.CommandsAndQueries.Users.DeleteUser
{
    public class DeleteUserCommandHandler(ETContext context) : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly ETContext _context = context;

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            Guid UserID = JwtDataProviderService.GetUserIDFromToken(request.HeaderData);

            if (UserID == Guid.Empty)
                throw new NotFoundException("Ваши данные не были найдены!");

            await _context.Users
                    .Where(p => p.Id == UserID)
                    .ExecuteDeleteAsync(cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
