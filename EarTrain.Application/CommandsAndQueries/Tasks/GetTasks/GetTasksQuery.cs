using EarTrain.Core.Enums;
using MediatR;
using System.Collections.Generic;

namespace EarTrain.Application.CommandsAndQueries.Tasks.GetTasks
{
    public record GetTasksQuery(SoundCategory SoundCategory, TaskCategory TaskCategory): IRequest<List<GetTasksResponse>>;
}
