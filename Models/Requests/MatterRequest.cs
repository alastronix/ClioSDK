using System.Text.Json.Serialization;

namespace ClioSDK.Models.Requests;

public class MatterRequest
{
    [JsonPropertyName("display_number")]
    public string? DisplayNumber { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("client")]
    public ContactReferenceRequest? Client { get; set; }

    [JsonPropertyName("practice_area")]
    public PracticeAreaReferenceRequest? PracticeArea { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("open_date")]
    public DateTime? OpenDate { get; set; }

    [JsonPropertyName("close_date")]
    public DateTime? CloseDate { get; set; }
}