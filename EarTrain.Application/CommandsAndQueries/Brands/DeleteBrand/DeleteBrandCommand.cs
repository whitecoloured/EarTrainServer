using MediatR;
using System;

namespace EarTrain.Application.CommandsAndQueries.Brands.DeleteBrand
{
    public record DeleteBrandCommand(Guid BrandID) :IRequest<Unit>;
}
