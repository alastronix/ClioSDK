using System.Text.Json.Serialization;

namespace ClioSDK.Models.Requests;

public class BankAccountRequest
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("number")]
    public string? Number { get; set; }

    [JsonPropertyName("bank_name")]
    public string? BankName { get; set; }

    [JsonPropertyName("account_type")]
    public string? AccountType { get; set; }

    [JsonPropertyName("balance")]
    public decimal? Balance { get; set; }
}
