using MediatR;

namespace EarTrain.Application.CommandsAndQueries.Tasks.DeleteTask
{
    public record DeleteTaskCommand(int ID) : IRequest<Unit>;
}
