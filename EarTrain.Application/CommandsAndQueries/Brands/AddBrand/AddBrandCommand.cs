using MediatR;

namespace EarTrain.Application.CommandsAndQueries.Brands.AddBrand
{
    public record AddBrandCommand(string Name) : IRequest<Unit>;
}
