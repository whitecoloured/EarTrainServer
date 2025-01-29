using MediatR;

namespace EarTrain.Application.CommandsAndQueries.Products.AddProduct
{
    public record AddProductCommand(ProductCommand ProductCommand) : IRequest<Unit>;
}
