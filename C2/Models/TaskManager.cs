using C2.Enums;
using System.Collections.Concurrent;

namespace C2.Models;

public class TaskManager
{
    public ConcurrentQueue<BotTask> Waiting = new();
    public ConcurrentDictionary<int, BotTask> Dispatched = new();
    public ConcurrentDictionary<int, BotTask> Executing = new();
    public ConcurrentBag<BotTask> Completed = new();

    public void QueueBotTask(TaskEnum task, Dictionary<string, object> parameters)
    {
        var botTask = new BotTask()
        {
            Id = Randomizer.GenerateInt(),
            Task = task,
            TaskParameters = parameters
        };

        Waiting.Enqueue(botTask);
    }

    public BotTask? DispatchTask()
    {

        if (Waiting.TryDequeue(out BotTask task))
        {
            if (task != null)
            {
                Dispatched.TryAdd(task.Id, task);
            }
            return task;
        }

        return null;
    }

    public bool AcceptTask(int taskId)
    {
        if (Dispatched.Remove(taskId, out BotTask task))
        {
            if (task != null)
            {
                Executing.TryAdd(task.Id, task);
            }
        }

        return false;
    }

    public bool CompleteTask(int taskId)
    {
        if (Executing.Remove(taskId, out BotTask task))
        {
            if (task != null)
            {
                Completed.Add(task);
                return true;
            }
        }

        return false;
    }
}
