
using EarTrain.Application.OtherServices.JWT;
using EarTrain.Core.Exceptions;
using EarTrain.Core.Models;
using EarTrain.Infrastructure.Context;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EarTrain.Application.CommandsAndQueries.Reviews.AddReview
{
    public class AddReviewCommandHandler(ETContext context, IValidator<ReviewCommand> validator) : IRequestHandler<AddReviewCommand, Unit>
    {
        private readonly ETContext _context = context;
        private readonly IValidator<ReviewCommand> _validator = validator;

        public async Task<Unit> Handle(AddReviewCommand request, CancellationToken cancellationToken)
        {
            var modelState=_validator.Validate(request.ReviewCommand);

            if (!modelState.IsValid)
            {
                throw new BadRequestException(string.Join('\n',modelState.Errors));
            }

            Guid UserID = JwtDataProviderService.GetUserIDFromToken(request.HeaderData);

            if (UserID==Guid.Empty)
            {
                throw new NotFoundException("Ваши данные не были найдены!");
            }

            var user = await _context.Users.FindAsync([UserID], cancellationToken) ?? throw new NotFoundException("Ваши данные не найдены!");
            var product = await _context.Products.FindAsync([request.ProductID], cancellationToken) ?? throw new NotFoundException("Продукт, к которому вы хотите оставить отзыв, не найден!");

            ProductReview review = ProductReview.Create(request.ReviewCommand.ReviewDesc, request.ReviewCommand.Mark, user, product);

            await _context.ProductReviews.AddAsync(review,cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
