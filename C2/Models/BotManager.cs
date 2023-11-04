using System.Collections.Concurrent;

namespace C2.Models;

public class BotManager
{
    public ConcurrentDictionary<int, BotClient> Bots = new();
}
