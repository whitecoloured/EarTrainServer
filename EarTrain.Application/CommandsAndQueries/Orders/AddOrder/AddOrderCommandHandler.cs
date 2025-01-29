

using EarTrain.Application.OtherServices.JWT;
using EarTrain.Core.Exceptions;
using EarTrain.Core.Models;
using EarTrain.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EarTrain.Application.CommandsAndQueries.Orders.AddOrder
{
    public class AddOrderCommandHandler(ETContext context) : IRequestHandler<AddOrderCommand, Unit>
    {
        private readonly ETContext _context = context;

        public async Task<Unit> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            Guid UserID = JwtDataProviderService.GetUserIDFromToken(request.HeaderData);

            if (UserID == Guid.Empty)
            {
                throw new NotFoundException("Ваши данные не найдены!");
            }

            if (!request.ProductIDs.Any())
            {
                throw new BadRequestException("Вы ничего не заказали!");
            }

            var user = await _context.Users.FindAsync([UserID], cancellationToken) ?? throw new NotFoundException("Ваши данные не найдены!");

            var products=await _context.Products
                                .Where(p=> request.ProductIDs.Contains(p.Id))
                                .ToArrayAsync(cancellationToken);

            Order order= Order.Create(user, products);

            await _context.Orders.AddAsync(order,cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        }
    }
}
