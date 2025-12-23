using System.Text.Json.Serialization;

namespace ClioSDK.Models.Requests;

public class BillRequest
{
    [JsonPropertyName("number")]
    public string? Number { get; set; }

    [JsonPropertyName("issue_date")]
    public DateTime? IssueDate { get; set; }

    [JsonPropertyName("due_date")]
    public DateTime? DueDate { get; set; }

    [JsonPropertyName("total")]
    public decimal? Total { get; set; }

    [JsonPropertyName("balance")]
    public decimal? Balance { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("matter")]
    public object? Matter { get; set; }

    [JsonPropertyName("client")]
    public object? Client { get; set; }
}
