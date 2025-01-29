

using EarTrain.Infrastructure.Context;
using EarTrain.Core.Exceptions;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using EarTrain.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EarTrain.Application.CommandsAndQueries.Products.AddProduct
{
    public class AddProductCommandHandler(ETContext context, IValidator<ProductCommand> validator) : IRequestHandler<AddProductCommand, Unit>
    {
        private readonly ETContext _context = context;
        private readonly IValidator<ProductCommand> _validator = validator;

        public async Task<Unit> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var modelState=_validator.Validate(request.ProductCommand);

            if (!modelState.IsValid)
            {
                throw new BadRequestException(string.Join('\n', modelState.Errors));
            }

            if (await _context.Products.AnyAsync(p => p.Name.ToLower() == request.ProductCommand.Name.ToLower() || p.Description.ToLower() == request.ProductCommand.Desc.ToLower(), cancellationToken))
            {
                throw new BadRequestException("Такой продукт уже есть в каталоге!");
            }

            var brand = await _context.ProductBrands.FindAsync([request.ProductCommand.BrandID], cancellationToken) ?? throw new NotFoundException("Бренд не был найден!");

            Product product = Product.Create(request.ProductCommand.Name, request.ProductCommand.Desc, request.ProductCommand.Category, brand, request.ProductCommand.Price, request.ProductCommand.Characteristics);

            await _context.Products.AddAsync(product, cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        }
    }
}
