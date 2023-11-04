using C2.Enums;

namespace C2.Models;

public class BotTask
{
    public int Id { get; set; }
    public TaskEnum Task { get; set; }

    public Dictionary<string, object> TaskParameters { get; set; }
}
