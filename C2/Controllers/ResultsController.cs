using C2.Models;
using C2.POCOs;
using Microsoft.AspNetCore.Mvc;

namespace C2.Controllers;

[ApiController]
[Route("[controller]")]
public class ResultsController : AbstractController
{
    [HttpGet("ResultsTest")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> ResultsTest() => Ok();
}
