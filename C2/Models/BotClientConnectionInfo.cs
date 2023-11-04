namespace C2.Models;

public class BotClientConnectionInfo
{
    public required string Ip { get; set; }

    public DateTime LastHeardFrom { get; set; }
}
