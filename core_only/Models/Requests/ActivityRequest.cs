using System.Text.Json.Serialization;

namespace ClioSDK.Models.Requests;

public class ActivityRequest
{
    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("note")]
    public string? Note { get; set; }

    [JsonPropertyName("matter")]
    public MatterReferenceRequest? Matter { get; set; }

    [JsonPropertyName("user")]
    public UserReferenceRequest? User { get; set; }

    [JsonPropertyName("quantity")]
    public decimal? Quantity { get; set; }

    [JsonPropertyName("date")]
    public DateTime? Date { get; set; }
}

public class MatterReferenceRequest
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
}

public class UserReferenceRequest
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
}

public class ContactReferenceRequest
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
}

public class PracticeAreaReferenceRequest
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
}