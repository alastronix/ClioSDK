using System.Text.Json.Serialization;

namespace ClioSDK.Models.Requests;

public class BillThemeRequest
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("content")]
    public string? Content { get; set; }

    [JsonPropertyName("default")]
    public bool? Default { get; set; }
}
