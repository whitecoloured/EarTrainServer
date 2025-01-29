using MediatR;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;

namespace EarTrain.Application.CommandsAndQueries.Orders.DeleteOrder
{
    public record DeleteOrderCommand(Guid OrderID, KeyValuePair<string, StringValues> HeaderData): IRequest<Unit>;
}
