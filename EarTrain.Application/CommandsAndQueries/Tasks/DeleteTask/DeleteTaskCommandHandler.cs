using EarTrain.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EarTrain.Application.CommandsAndQueries.Tasks.DeleteTask
{
    public class DeleteTaskCommandHandler(ETContext context) : IRequestHandler<DeleteTaskCommand, Unit>
    {
        private readonly ETContext _context = context;
        public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            await _context.Tasks
                    .Where(p=> p.Id==request.ID)
                    .ExecuteDeleteAsync(cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
