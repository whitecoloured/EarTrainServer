

using EarTrain.Application.OtherServices.JWT;
using EarTrain.Infrastructure.Context;
using EarTrain.Core.Exceptions;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using EarTrain.Core.Models;

namespace EarTrain.Application.CommandsAndQueries.Cart.AddCartItem
{
    public class AddCartItemCommandHandler(ETContext context) : IRequestHandler<AddCartItemCommand, Unit>
    {
        private readonly ETContext _context = context;

        public async Task<Unit> Handle(AddCartItemCommand request, CancellationToken cancellationToken)
        {
            Guid UserID = JwtDataProviderService.GetUserIDFromToken(request.HeaderData);
            if (UserID == Guid.Empty)
            {
                throw new BadRequestException("Ваши данные не найдены!");
            }

            var product = await _context.Products.FindAsync([request.ProductID], cancellationToken) ?? throw new NotFoundException("Продукт, который вы хотите поместить в корзину, не найден!");
            var user = await _context.Users.FindAsync([UserID], cancellationToken) ?? throw new NotFoundException("Ваши данные не были найдены!");

            CartItem cartItem= CartItem.Create(product, user);

            await _context.Cart.AddAsync(cartItem,cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
