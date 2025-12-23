using System.Text.Json.Serialization;

namespace ClioSDK.Models.Requests;

public class GroupRequest
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("members")]
    public object[]? Members { get; set; }
}
