using MediatR;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;

namespace EarTrain.Application.CommandsAndQueries.Cart.DeleteCartItem
{
    public record DeleteCartItemsCommand(IEnumerable<Guid> CartItemsIDs, KeyValuePair<string, StringValues> HeaderData) : IRequest<Unit>;
}
