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
        // Generate new BotClient
        string name = RandomNameGenerator.GenerateNew();
        int id = RandomNameGenerator.Random.Next();

        var initialResponse = new InitialResponse()
        {
            Name = name,
            Id = id
        };
        return Ok(initialResponse);
    }
}
