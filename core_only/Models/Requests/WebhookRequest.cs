using System.Text.Json.Serialization;

namespace ClioSDK.Models.Requests;

public class WebhookRequest
{
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("events")]
    public string[]? Events { get; set; }

    [JsonPropertyName("active")]
    public bool? Active { get; set; }
}
