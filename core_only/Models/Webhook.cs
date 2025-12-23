using System.Text.Json.Serialization;
using ClioSDK.Core;

namespace ClioSDK.Models;

public class Webhook : BaseModel
{
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("event_type")]
    public string? EventType { get; set; }

    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("secret")]
    public string? Secret { get; set; }
}

public class WebhookRequest
{
    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("event_type")]
    public string? EventType { get; set; }

    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("secret")]
    public string? Secret { get; set; }
}