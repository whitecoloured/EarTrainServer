using EarTrain.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EarTrain.Application.CommandsAndQueries.Products.DeleteProduct
{
    public class DeleteProductCommandHandler(ETContext context) : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly ETContext _context = context;

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _context.Products
                    .Where(p=> p.Id==request.ProductID)
                    .ExecuteDeleteAsync(cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
