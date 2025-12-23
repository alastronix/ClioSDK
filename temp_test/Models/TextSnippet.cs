using System.Text.Json.Serialization;
using ClioSDK.Core;

namespace ClioSDK.Models;

public class TextSnippet : BaseModel
{
    [JsonPropertyName("name")]
    public string? name { get; set; }
    [JsonPropertyName("content")]
    public string? content { get; set; }
    [JsonPropertyName("category")]
    public string? category { get; set; }
}

public class TextSnippetRequest
{
    [JsonPropertyName("name")]
    public string? name { get; set; }
    [JsonPropertyName("content")]
    public string? content { get; set; }
    [JsonPropertyName("category")]
    public string? category { get; set; }
}