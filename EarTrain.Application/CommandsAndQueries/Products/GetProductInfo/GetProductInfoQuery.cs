using MediatR;
using System;

namespace EarTrain.Application.CommandsAndQueries.Products.GetProductInfo
{
    public record GetProductInfoQuery(Guid ProductID): IRequest<GetProductInfoResponse>;
}
