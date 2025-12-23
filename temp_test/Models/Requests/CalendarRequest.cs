using System.Text.Json.Serialization;

namespace ClioSDK.Models.Requests;

public class CalendarRequest
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("default")]
    public bool? Default { get; set; }
}
