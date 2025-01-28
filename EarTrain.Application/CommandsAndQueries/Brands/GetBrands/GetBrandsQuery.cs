using MediatR;
using System.Collections.Generic;

namespace EarTrain.Application.CommandsAndQueries.Brands.GetBrands
{
    public record GetBrandsQuery() : IRequest<List<GetBrandsResponse>>;
}
