using System.Text.Json.Serialization;

namespace ClioSDK.Models.Requests;

public class ClioPaymentsLinkRequest
{
    [JsonPropertyName("amount")]
    public decimal? Amount { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("bill")]
    public object? Bill { get; set; }

    [JsonPropertyName("contact")]
    public object? Contact { get; set; }
}
