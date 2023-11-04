using C2.Enums;

namespace C2.Models;

public class AddedBotTask
{
    public TaskEnum Task { get; set; }

    public Dictionary<string, object> TaskParameters { get; set; }
}
