using MediatR;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;

namespace EarTrain.Application.CommandsAndQueries.Reviews.EditReview
{
    public record EditReviewCommand(ReviewCommand ReviewCommand, Guid ReviewID, KeyValuePair<string,StringValues> HeaderData): IRequest<Unit>;
}
