

using EarTrain.Application.OtherServices.JWT;
using EarTrain.Core.Exceptions;
using EarTrain.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EarTrain.Application.CommandsAndQueries.Cart.DeleteCartItem
{
    public class DeleteCartItemsCommandHandler(ETContext context) : IRequestHandler<DeleteCartItemsCommand, Unit>
    {
        private readonly ETContext _context = context;

        public async Task<Unit> Handle(DeleteCartItemsCommand request, CancellationToken cancellationToken)
        {
            Guid UserID = JwtDataProviderService.GetUserIDFromToken(request.HeaderData);

            if (UserID == Guid.Empty)
            {
                throw new BadRequestException("Ваши данные не найдены!");
            }

            await _context.Cart
                    .Where(p=> request.CartItemsIDs.Contains(p.Id) && p.UserID == UserID)
                    .ExecuteDeleteAsync(cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
