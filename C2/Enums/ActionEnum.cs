using System.Text.Json.Serialization;

namespace C2.Enums;
//
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ActionEnum
{
    REQUEST,
    CONTINUE,
    STOP,
    REGISTER
}
