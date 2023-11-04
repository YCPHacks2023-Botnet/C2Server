namespace C2.Models;

public class BotClient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public BotClientConnectionInfo ConnectionInfo { get; set; }
    public BotClientSpecs BotClientSpecs { get; set; }

}
