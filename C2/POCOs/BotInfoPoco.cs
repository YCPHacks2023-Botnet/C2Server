using C2.Models;

namespace C2.POCOs;

public class BotInfoPoco
{
    public required BotClient Bot { get; set; }
    public BotTask? Task { get; set; }
}
