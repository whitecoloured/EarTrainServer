using MediatR;
using System;

namespace EarTrain.Application.CommandsAndQueries.Products.DeleteProduct
{
    public record DeleteProductCommand(Guid ProductID): IRequest<Unit>;
}
