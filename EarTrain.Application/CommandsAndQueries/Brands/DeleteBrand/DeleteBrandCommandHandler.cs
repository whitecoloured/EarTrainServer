

using EarTrain.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EarTrain.Application.CommandsAndQueries.Brands.DeleteBrand
{
    public class DeleteBrandCommandHandler(ETContext context) : IRequestHandler<DeleteBrandCommand, Unit>
    {
        private readonly ETContext _context = context;

        public async Task<Unit> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            await _context.ProductBrands
                    .Where(p=> p.ID==request.BrandID)
                    .ExecuteDeleteAsync(cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
