using System.Text.Json.Serialization;

namespace ClioSDK.Models.Requests;

public class TaskRequest
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("due_date")]
    public DateTime? DueDate { get; set; }

    [JsonPropertyName("priority")]
    public int? Priority { get; set; }

    [JsonPropertyName("assignee")]
    public UserReferenceRequest? Assignee { get; set; }

    [JsonPropertyName("matter")]
    public MatterReferenceRequest? Matter { get; set; }
}