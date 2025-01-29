using EarTrain.Application.OtherServices.JWT;
using EarTrain.Core.Exceptions;
using EarTrain.Infrastructure.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EarTrain.Application.CommandsAndQueries.Reviews.DeleteReview
{
    public class DeleteReviewCommandHandler(ETContext context) : IRequestHandler<DeleteReviewCommand, Unit>
    {
        private readonly ETContext _context = context;

        public async Task<Unit> Handle(DeleteReviewCommand request, CancellationToken cancellationToken)
        {
            Guid UserID = JwtDataProviderService.GetUserIDFromToken(request.HeaderData);

            if (UserID==Guid.Empty)
            {
                throw new NotFoundException("Ваши данные не были найдены!");
            }

            await _context.ProductReviews
                    .Where(p => p.Id == request.ReviewID && p.UserID == UserID)
                    .ExecuteDeleteAsync(cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
