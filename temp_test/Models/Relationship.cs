using System.Text.Json.Serialization;
using ClioSDK.Core;

namespace ClioSDK.Models;

public class Relationship : BaseModel
{
    [JsonPropertyName("description")]
    public string? description { get; set; }
    [JsonPropertyName("contact")]
    public string? contact { get; set; }
    [JsonPropertyName("related_contact")]
    public string? related_contact { get; set; }
    [JsonPropertyName("relationship_type")]
    public string? relationship_type { get; set; }
}

public class RelationshipRequest
{
    [JsonPropertyName("description")]
    public string? description { get; set; }
    [JsonPropertyName("contact")]
    public string? contact { get; set; }
    [JsonPropertyName("related_contact")]
    public string? related_contact { get; set; }
    [JsonPropertyName("relationship_type")]
    public string? relationship_type { get; set; }
}