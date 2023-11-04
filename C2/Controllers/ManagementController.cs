using Microsoft.AspNetCore.Mvc;

namespace C2.Controllers;

[ApiController]
[Route("[controller]")]
public class ManagementController : AbstractController
{
    [HttpGet("ManagementTest")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> ManagementTest()
    {
        return Ok();
    }
}
