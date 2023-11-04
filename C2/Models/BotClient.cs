using C2.Enums;

namespace C2.Models;

public class BotClient
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int TaskId { get; set; }
    public BotResult BotResult { get; set; } = new BotResult();
    public ProgressEnum CurrentProgress { get; set; }
    public bool StopRequested { get; set; }
    public List<string> Output { get; set; } = new List<string>();
    public required BotClientConnectionInfo ConnectionInfo { get; set; }
    public required BotClientSpecs BotClientSpecs { get; set; }
}
