using System.Text.Json.Serialization;
using ClioSDK.Core;

namespace ClioSDK.Models;

public class TrustAccount : BaseModel
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("bank_name")]
    public string? BankName { get; set; }

    [JsonPropertyName("account_number")]
    public string? AccountNumber { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("balance")]
    public decimal? Balance { get; set; }

    [JsonPropertyName("reconciled_balance")]
    public decimal? ReconciledBalance { get; set; }
}

public class TrustAccountRequest
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("bank_name")]
    public string? BankName { get; set; }

    [JsonPropertyName("account_number")]
    public string? AccountNumber { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}