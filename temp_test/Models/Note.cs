using System.Text.Json.Serialization;
using ClioSDK.Core;

namespace ClioSDK.Models;

public class Note : BaseModel
{
    [JsonPropertyName("detail")]
    public string? Detail { get; set; }

    [JsonPropertyName("matter")]
    public MatterReference? Matter { get; set; }

    [JsonPropertyName("contact")]
    public ContactReference? Contact { get; set; }

    [JsonPropertyName("user")]
    public UserReference? User { get; set; }

    [JsonPropertyName("date")]
    public DateTime? Date { get; set; }
}

public class NoteRequest
{
    [JsonPropertyName("detail")]
    public string? Detail { get; set; }

    [JsonPropertyName("matter")]
    public MatterReferenceRequest? Matter { get; set; }

    [JsonPropertyName("contact")]
    public ContactReferenceRequest? Contact { get; set; }
}