using C2.Models;
using Microsoft.AspNetCore.Mvc;

namespace C2.Controllers;

[Controller]
public abstract class AbstractController : ControllerBase
{
    [NonAction]
    public static BotClient GetBot(int id) => C2State.BotManager.Bots[id];
}
