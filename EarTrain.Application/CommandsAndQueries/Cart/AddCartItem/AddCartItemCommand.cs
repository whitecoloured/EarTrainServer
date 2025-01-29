

using MediatR;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;

namespace EarTrain.Application.CommandsAndQueries.Cart.AddCartItem
{
    public record AddCartItemCommand(Guid ProductID, KeyValuePair<string,StringValues> HeaderData): IRequest<Unit>;
}
