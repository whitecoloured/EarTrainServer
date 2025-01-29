using MediatR;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;

namespace EarTrain.Application.CommandsAndQueries.Orders.AddOrder
{
    public record AddOrderCommand(KeyValuePair<string, StringValues> HeaderData, IEnumerable<Guid> ProductIDs) : IRequest<Unit>;
}
