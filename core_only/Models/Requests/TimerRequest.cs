using System.Text.Json.Serialization;

namespace ClioSDK.Models.Requests;

public class TimerRequest
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("duration")]
    public int? Duration { get; set; }

    [JsonPropertyName("user")]
    public object? User { get; set; }

    [JsonPropertyName("matter")]
    public object? Matter { get; set; }

    [JsonPropertyName("note")]
    public string? Note { get; set; }

    [JsonPropertyName("billed")]
    public bool? Billed { get; set; }
}
