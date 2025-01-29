using MediatR;
using System;

namespace EarTrain.Application.CommandsAndQueries.Products.EditProduct
{
    public record EditProductCommand(ProductCommand ProductCommand, Guid ProductID) :IRequest<Unit>;
}
