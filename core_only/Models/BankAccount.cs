using System.Text.Json.Serialization;
using ClioSDK.Core;

namespace ClioSDK.Models;

public class BankAccount : BaseModel
{
    [JsonPropertyName("name")]
    public string? name { get; set; }
    [JsonPropertyName("bank_name")]
    public string? bank_name { get; set; }
    [JsonPropertyName("account_number")]
    public string? account_number { get; set; }
    [JsonPropertyName("routing_number")]
    public string? routing_number { get; set; }
    [JsonPropertyName("account_type")]
    public string? account_type { get; set; }
    [JsonPropertyName("balance")]
    public decimal? balance { get; set; }
}

public class BankAccountRequest
{
    [JsonPropertyName("name")]
    public string? name { get; set; }
    [JsonPropertyName("bank_name")]
    public string? bank_name { get; set; }
    [JsonPropertyName("account_number")]
    public string? account_number { get; set; }
    [JsonPropertyName("routing_number")]
    public string? routing_number { get; set; }
    [JsonPropertyName("account_type")]
    public string? account_type { get; set; }
    [JsonPropertyName("balance")]
    public decimal? balance { get; set; }
}