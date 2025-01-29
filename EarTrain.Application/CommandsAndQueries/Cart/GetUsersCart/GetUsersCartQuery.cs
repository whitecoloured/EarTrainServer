using MediatR;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;

namespace EarTrain.Application.CommandsAndQueries.Cart.GetUsersCart
{
    public record GetUsersCartQuery(KeyValuePair<string, StringValues> HeaderData): IRequest<List<GetUsersCartResponse>>;
}
