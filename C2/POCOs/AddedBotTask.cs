using C2.Enums;

namespace C2.POCOs;

public class AddedBotTask
{
    public TaskEnum Task { get; set; }

    public required Dictionary<string, object> TaskParameters { get; set; }
}
