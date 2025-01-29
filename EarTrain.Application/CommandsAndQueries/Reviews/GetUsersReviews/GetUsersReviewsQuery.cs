using MediatR;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;

namespace EarTrain.Application.CommandsAndQueries.Reviews.GetUsersReviews
{
    public record GetUsersReviewsQuery(KeyValuePair<string, StringValues> HeaderData) : IRequest<List<GetUsersReviewsResponse>>;
}
