using EarTrain.Core.Exceptions;
using EarTrain.Core.Models;
using EarTrain.Infrastructure.Context;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EarTrain.Application.CommandsAndQueries.Brands.AddBrand
{
    public class AddBrandCommandHandler(ETContext context, IValidator<AddBrandCommand> validator) : IRequestHandler<AddBrandCommand, Unit>
    {
        private readonly ETContext _context = context;
        private readonly IValidator<AddBrandCommand> _validator = validator;

        public async Task<Unit> Handle(AddBrandCommand request, CancellationToken cancellationToken)
        {
            var modelState = _validator.Validate(request);

            if (!modelState.IsValid)
            {
                throw new BadRequestException(string.Join('\n',modelState.Errors));
            }

            ProductBrand brand = ProductBrand.Create(request.Name);

            await _context.ProductBrands.AddAsync(brand, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
