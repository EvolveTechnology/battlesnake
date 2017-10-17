using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace NetSnake.Model
{
    public class Move
    {
        [JsonConverter(typeof(StringEnumConverter))]
        [JsonProperty("move")]
        public Direction Direction;

        [JsonProperty("taunt")]
        public string Taunt;
    }

    public enum Direction
    {
        [EnumMember(Value = "up")]
        Up = 0,

        [EnumMember(Value = "down")]
        Down = 1,

        [EnumMember(Value = "left")]
        Left = 2,

        [EnumMember(Value = "right")]
        Right = 3
    }
}