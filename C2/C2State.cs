using C2.Models;
using Server.Security;

namespace C2;

public static class C2State
{
    public static BotManager BotManager = new();
    public static TaskManager TaskManager = new();
    public static SecurityHandler SecurityHandler = new();
}