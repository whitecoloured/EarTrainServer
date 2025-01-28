using MediatR;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;

namespace EarTrain.Application.CommandsAndQueries.Users.GetUserData
{
    public record GetUserDataQuery(KeyValuePair<string, StringValues> HeaderData): IRequest<GetUserDataResponse>;
}
