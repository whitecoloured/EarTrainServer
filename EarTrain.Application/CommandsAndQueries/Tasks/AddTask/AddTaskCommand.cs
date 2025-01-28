using EarTrain.Core.Enums;
using MediatR;

namespace EarTrain.Application.CommandsAndQueries.Tasks.AddTask
{
    public record AddTaskCommand(TaskCommand Command) : IRequest<Unit>;
}
