using C2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace C2.Controllers;

[ApiController]
[Route("[controller]")]
public class ManagementController : AbstractController
{
    [HttpGet("ManagementTest")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> ManagementTest() => Ok();

    [HttpGet("GetBotManager")]
    [ProducesResponseType(typeof(BotManager), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetBotManager()
    {
        return Ok(C2State.BotManager.Bots);
    }

    [HttpGet("GetWaitingTasks")]
    [ProducesResponseType(typeof(ConcurrentQueue<BotTask>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetWaitingTasks()
    {
        return Ok(C2State.TaskManager.Waiting);
    }

    [HttpGet("GetDispatchedTasks")]
    [ProducesResponseType(typeof(ConcurrentBag<BotTask>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDispatchedTasks()
    {
        return Ok(C2State.TaskManager.Dispatched);
    }

    [HttpGet("GetExecutingTasks")]
    [ProducesResponseType(typeof(ConcurrentDictionary<int, BotTask>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetExecutingTasks()
    {
        return Ok(C2State.TaskManager.Executing);
    }

    [HttpGet("GetCompletedTasks")]
    [ProducesResponseType(typeof(ConcurrentBag<BotTask>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCompletedTasks()
    {
        return Ok(C2State.TaskManager.Completed);
    }

}
