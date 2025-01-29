

using MediatR;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;

namespace EarTrain.Application.CommandsAndQueries.Orders.GetUsersOrders
{
    public record GetUsersOrdersQuery(KeyValuePair<string, StringValues> HeaderData) : IRequest<List<GetUsersOrdersResponse>>;
}
