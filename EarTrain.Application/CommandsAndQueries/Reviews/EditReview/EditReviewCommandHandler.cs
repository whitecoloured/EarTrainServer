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

namespace EarTrain.Application.CommandsAndQueries.Reviews.EditReview
{
    public class EditReviewCommandHandler(ETContext context, IValidator<ReviewCommand> validator) : IRequestHandler<EditReviewCommand, Unit>
    {
        private readonly ETContext _context = context;
        private readonly IValidator<ReviewCommand> _validator = validator;

        public async Task<Unit> Handle(EditReviewCommand request, CancellationToken cancellationToken)
        {
            var modelState=_validator.Validate(request.ReviewCommand);

            if (!modelState.IsValid)
            {
                throw new BadRequestException(string.Join('\n', modelState.Errors));
            }

            Guid UserID = JwtDataProviderService.GetUserIDFromToken(request.HeaderData);

            if (UserID==Guid.Empty)
            {
                throw new NotFoundException("Ваши данные не найдены!");
            }

            await _context.ProductReviews
                    .Where(p => p.Id == request.ReviewID && p.UserID==UserID)
                    .ExecuteUpdateAsync(opt =>
                        opt
                        .SetProperty(p => p.ReviewDesc, request.ReviewCommand.ReviewDesc)
                        .SetProperty(p => p.Mark, request.ReviewCommand.Mark),
                        cancellationToken
                        );

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
