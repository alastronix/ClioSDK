using System.Text.Json.Serialization;
using ClioSDK.Core;

namespace ClioSDK.Models;

public class PracticeArea : BaseModel
{
    [JsonPropertyName("name")]
    public string? name { get; set; }
    [JsonPropertyName("description")]
    public string? description { get; set; }
    [JsonPropertyName("default_rate")]
    public decimal? default_rate { get; set; }
    [JsonPropertyName("enabled")]
    public bool? enabled { get; set; }
}

public class PracticeAreaRequest
{
    [JsonPropertyName("name")]
    public string? name { get; set; }
    [JsonPropertyName("description")]
    public string? description { get; set; }
    [JsonPropertyName("default_rate")]
    public decimal? default_rate { get; set; }
    [JsonPropertyName("enabled")]
    public bool? enabled { get; set; }
}