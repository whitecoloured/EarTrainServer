

using EarTrain.Infrastructure.Context;
using EarTrain.Core.Exceptions;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EarTrain.Application.CommandsAndQueries.Products.EditProduct
{
    public class EditProductCommandHandler(ETContext context, IValidator<ProductCommand> validator) : IRequestHandler<EditProductCommand, Unit>
    {
        private readonly ETContext _context = context;
        private readonly IValidator<ProductCommand> _validator = validator;

        public async Task<Unit> Handle(EditProductCommand request, CancellationToken cancellationToken)
        {
            var modelState= _validator.Validate(request.ProductCommand);

            if (!modelState.IsValid)
            {
                throw new BadRequestException(string.Join('\n', modelState.Errors));
            }

            if (await _context.Products.AnyAsync(p => (p.Name.ToLower()==request.ProductCommand.Name.ToLower() || p.Description.ToLower()==request.ProductCommand.Desc.ToLower()) && p.Id!=request.ProductID , cancellationToken))
            {
                throw new BadRequestException("Такой продукт уже существует в каталоге!");
            }

            var newBrand = await _context.ProductBrands.FindAsync([request.ProductCommand.BrandID], cancellationToken) ?? throw new NotFoundException("Бренд был не найден!");

            await _context.Products
                    .Where(p => p.Id == request.ProductID)
                    .ExecuteUpdateAsync(opt =>
                        opt
                        .SetProperty(p=> p.Name, request.ProductCommand.Name)
                        .SetProperty(p=> p.Description, request.ProductCommand.Desc)
                        .SetProperty(p=> p.Category, request.ProductCommand.Category)
                        .SetProperty(p=> p.Brand, newBrand)
                        .SetProperty(p=> p.Price, request.ProductCommand.Price)
                        .SetProperty(p=> p.Characteristics, request.ProductCommand.Characteristics),
                        cancellationToken
                        );

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
