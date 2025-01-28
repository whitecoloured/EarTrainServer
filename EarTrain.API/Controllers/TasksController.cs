using EarTrain.Application.CommandsAndQueries.Tasks.GetTasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EarTrain.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [HttpGet]
        [Route("GetTasks")]
        public async Task<IActionResult> GetTasks([FromQuery]GetTasksQuery query, CancellationToken ct)
        {
            var data = await _sender.Send(query,ct);
            return Ok(data);
        }
    }
}
