using System.Text.Json.Serialization;

namespace ClioSDK.Models.Requests;

public class ImportConfigurationRequest
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("configuration")]
    public object? Configuration { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }
}
