namespace C2.Models;

public class BotClient
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int TaskId { get; set; }
    public required BotClientConnectionInfo ConnectionInfo { get; set; }
    public required BotClientSpecs BotClientSpecs { get; set; }
}
