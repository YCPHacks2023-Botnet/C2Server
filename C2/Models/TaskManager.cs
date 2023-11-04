using System.Collections.Concurrent;

namespace C2.Models;

public class TaskManager
{
    public ConcurrentQueue<BotTask> Waiting = new();
    public ConcurrentBag<BotTask> Dispatched = new();
    public ConcurrentDictionary<int, BotTask> Executing = new();
    public ConcurrentBag<BotTask> Completed = new();
}
