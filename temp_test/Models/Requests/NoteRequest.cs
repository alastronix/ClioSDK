using System.Text.Json.Serialization;

namespace ClioSDK.Models.Requests;

public class NoteRequest
{
    [JsonPropertyName("content")]
    public string? Content { get; set; }

    [JsonPropertyName("matter")]
    public object? Matter { get; set; }

    [JsonPropertyName("contact")]
    public object? Contact { get; set; }

    [JsonPropertyName("user")]
    public object? User { get; set; }

    [JsonPropertyName("date")]
    public DateTime? Date { get; set; }
}
