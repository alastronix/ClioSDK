using System.Text.Json.Serialization;
using ClioSDK.Core;

namespace ClioSDK.Models;

public class BankTransaction : BaseModel
{
    [JsonPropertyName("description")]
    public string? description { get; set; }
    [JsonPropertyName("amount")]
    public decimal? amount { get; set; }
    [JsonPropertyName("date")]
    public DateTime? date { get; set; }
    [JsonPropertyName("transaction_type")]
    public string? transaction_type { get; set; }
    [JsonPropertyName("reference")]
    public string? reference { get; set; }
}

public class BankTransactionRequest
{
    [JsonPropertyName("description")]
    public string? description { get; set; }
    [JsonPropertyName("amount")]
    public decimal? amount { get; set; }
    [JsonPropertyName("date")]
    public DateTime? date { get; set; }
    [JsonPropertyName("transaction_type")]
    public string? transaction_type { get; set; }
    [JsonPropertyName("reference")]
    public string? reference { get; set; }
}