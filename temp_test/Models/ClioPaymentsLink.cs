using System.Text.Json.Serialization;
using ClioSDK.Core;

namespace ClioSDK.Models;

public class ClioPaymentsLink : BaseModel
{
    [JsonPropertyName("url")]
    public string? url { get; set; }
    [JsonPropertyName("amount")]
    public decimal? amount { get; set; }
    [JsonPropertyName("currency")]
    public string? currency { get; set; }
    [JsonPropertyName("status")]
    public string? status { get; set; }
    [JsonPropertyName("expires_at")]
    public DateTime? expires_at { get; set; }
}

public class ClioPaymentsLinkRequest
{
    [JsonPropertyName("url")]
    public string? url { get; set; }
    [JsonPropertyName("amount")]
    public decimal? amount { get; set; }
    [JsonPropertyName("currency")]
    public string? currency { get; set; }
    [JsonPropertyName("status")]
    public string? status { get; set; }
    [JsonPropertyName("expires_at")]
    public DateTime? expires_at { get; set; }
}