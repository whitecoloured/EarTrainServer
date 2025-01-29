using MediatR;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;

namespace EarTrain.Application.CommandsAndQueries.Reviews.GetProductsReviews
{
    public record GetProductsReviewsQuery(string SortItem, bool OrderByAsc, KeyValuePair<string,StringValues> HeaderData): IRequest<List<GetProductsReviewsResponse>>;
}
