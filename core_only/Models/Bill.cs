using System.Text.Json.Serialization;
using ClioSDK.Core;

namespace ClioSDK.Models;

public class Bill : BaseModel
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

    [JsonPropertyName("client")]
    public ContactReference? Client { get; set; }

    [JsonPropertyName("matter")]
    public MatterReference? Matter { get; set; }

    [JsonPropertyName("line_items")]
    public List<LineItem>? LineItems { get; set; }
}

public class BillRequest
{
    [JsonPropertyName("issue_date")]
    public DateTime? IssueDate { get; set; }

    [JsonPropertyName("due_date")]
    public DateTime? DueDate { get; set; }

    [JsonPropertyName("client")]
    public ContactReferenceRequest? Client { get; set; }

    [JsonPropertyName("matter")]
    public MatterReferenceRequest? Matter { get; set; }
}