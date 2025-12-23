using System.Text.Json.Serialization;

namespace ClioSDK.Models.Requests;

public class CalendarEntrieRequest
{
    [JsonPropertyName("summary")]
    public string? Summary { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("start_at")]
    public DateTime? StartAt { get; set; }

    [JsonPropertyName("end_at")]
    public DateTime? EndAt { get; set; }

    [JsonPropertyName("calendar")]
    public object? Calendar { get; set; }

    [JsonPropertyName("attendees")]
    public object[]? Attendees { get; set; }
}
