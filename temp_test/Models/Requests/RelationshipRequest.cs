using System.Text.Json.Serialization;

namespace ClioSDK.Models.Requests;

public class RelationshipRequest
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("contacts")]
    public object[]? Contacts { get; set; }

    [JsonPropertyName("matters")]
    public object[]? Matters { get; set; }
}
