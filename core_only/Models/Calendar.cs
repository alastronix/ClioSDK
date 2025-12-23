using System.Text.Json.Serialization;
using ClioSDK.Core;

namespace ClioSDK.Models;

public class Calendar : BaseModel
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("color")]
    public string? Color { get; set; }

    [JsonPropertyName("default")]
    public bool? Default { get; set; }
}

public class CalendarRequest
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("color")]
    public string? Color { get; set; }

    [JsonPropertyName("default")]
    public bool? Default { get; set; }
}