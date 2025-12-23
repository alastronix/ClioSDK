using System.Text.Json.Serialization;
using ClioSDK.Core;

namespace ClioSDK.Models;

public class Timer : BaseModel
{
    [JsonPropertyName("duration")]
    public int? Duration { get; set; }

    [JsonPropertyName("started_at")]
    public DateTime? StartedAt { get; set; }

    [JsonPropertyName("stopped_at")]
    public DateTime? StoppedAt { get; set; }

    [JsonPropertyName("user")]
    public UserReference? User { get; set; }

    [JsonPropertyName("matter")]
    public MatterReference? Matter { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }
}

public class TimerRequest
{
    [JsonPropertyName("duration")]
    public int? Duration { get; set; }

    [JsonPropertyName("matter")]
    public MatterReferenceRequest? Matter { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }
}