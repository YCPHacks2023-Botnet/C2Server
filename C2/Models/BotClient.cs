using C2.Enums;
using C2.POCOs;

namespace C2.Models;

public class BotClient
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public StrippedLocationInfo locationInfo { get; set; } = null;
    public int TaskId { get; set; }
    public BotResult BotResult { get; set; } = new BotResult();
    public ProgressEnum CurrentProgress { get; set; }
    public bool StopRequested { get; set; }
    public List<string> Output { get; set; } = new List<string>();
    public bool OutputRetrieved = false;
    public required BotClientConnectionInfo ConnectionInfo { get; set; }
    public required BotClientSpecs BotClientSpecs { get; set; }
    public List<BotTask> CompletedTasks { get; set; } = new List<BotTask>();
}
