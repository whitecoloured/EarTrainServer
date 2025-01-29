using MediatR;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;

namespace EarTrain.Application.CommandsAndQueries.Reviews.AddReview
{
    public record AddReviewCommand(ReviewCommand ReviewCommand, Guid ProductID, KeyValuePair<string, StringValues> HeaderData) : IRequest<Unit>;
}
