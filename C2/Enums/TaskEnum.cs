using System.Text.Json.Serialization;

namespace C2.Enums;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TaskEnum
{
    DDOS,
    KEY_LOG,
    PORT_SCAN,
    QUACK,
    STORAGE
}
