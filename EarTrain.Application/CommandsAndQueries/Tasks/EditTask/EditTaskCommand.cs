using MediatR;

namespace EarTrain.Application.CommandsAndQueries.Tasks.EditTask
{
    public record EditTaskCommand(TaskCommand Command, int TaskID) :IRequest<Unit>;
}
