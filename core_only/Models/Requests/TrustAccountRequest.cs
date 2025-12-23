using System.Text.Json.Serialization;

namespace ClioSDK.Models.Requests;

public class TrustAccountRequest
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("number")]
    public string? Number { get; set; }

    [JsonPropertyName("balance")]
    public decimal? Balance { get; set; }

    [JsonPropertyName("bank")]
    public object? Bank { get; set; }
}
