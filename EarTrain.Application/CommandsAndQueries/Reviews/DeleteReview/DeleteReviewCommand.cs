using MediatR;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;

namespace EarTrain.Application.CommandsAndQueries.Reviews.DeleteReview
{
    public record DeleteReviewCommand(Guid ReviewID, KeyValuePair<string, StringValues> HeaderData): IRequest<Unit>;
}
