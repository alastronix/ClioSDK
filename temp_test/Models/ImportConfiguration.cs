using System.Text.Json.Serialization;
using ClioSDK.Core;

namespace ClioSDK.Models;

public class ImportConfiguration : BaseModel
{
    [JsonPropertyName("name")]
    public string? name { get; set; }
    [JsonPropertyName("configuration_type")]
    public string? configuration_type { get; set; }
    [JsonPropertyName("status")]
    public string? status { get; set; }
}

public class ImportConfigurationRequest
{
    [JsonPropertyName("name")]
    public string? name { get; set; }
    [JsonPropertyName("configuration_type")]
    public string? configuration_type { get; set; }
    [JsonPropertyName("status")]
    public string? status { get; set; }
}