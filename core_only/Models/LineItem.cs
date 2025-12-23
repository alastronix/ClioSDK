using System.Text.Json.Serialization;
using ClioSDK.Core;

namespace ClioSDK.Models;

public class LineItem : BaseModel
{
    [JsonPropertyName("description")]
    public string? description { get; set; }
    [JsonPropertyName("quantity")]
    public decimal? quantity { get; set; }
    [JsonPropertyName("unit_price")]
    public decimal? unit_price { get; set; }
    [JsonPropertyName("total")]
    public decimal? total { get; set; }
    [JsonPropertyName("type")]
    public string? type { get; set; }
    [JsonPropertyName("bill")]
    public string? bill { get; set; }
}

public class LineItemRequest
{
    [JsonPropertyName("description")]
    public string? description { get; set; }
    [JsonPropertyName("quantity")]
    public decimal? quantity { get; set; }
    [JsonPropertyName("unit_price")]
    public decimal? unit_price { get; set; }
    [JsonPropertyName("total")]
    public decimal? total { get; set; }
    [JsonPropertyName("type")]
    public string? type { get; set; }
    [JsonPropertyName("bill")]
    public string? bill { get; set; }
}