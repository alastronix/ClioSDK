using System.Text.Json.Serialization;

namespace ClioSDK.Models.Requests;

public class TextSnippetRequest
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("content")]
    public string? Content { get; set; }

    [JsonPropertyName("category")]
    public string? Category { get; set; }

    [JsonPropertyName("shortcut")]
    public string? Shortcut { get; set; }
}
