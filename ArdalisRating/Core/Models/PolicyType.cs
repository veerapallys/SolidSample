using System;
using System.Text.Json.Serialization;

namespace ArdalisRating
{

[JsonConverter(typeof(JsonStringEnumConverter<PolicyType>))]
    public enum PolicyType
    {
        Life = 0,
        Land = 1,
        Auto = 2
    }
}
