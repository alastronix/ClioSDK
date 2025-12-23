using System.Text.Json.Serialization;

namespace ClioSDK.Models.Requests;

public class BankTransactionRequest
{
    [JsonPropertyName("amount")]
    public decimal? Amount { get; set; }

    [JsonPropertyName("date")]
    public DateTime? Date { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("bank_account")]
    public object? BankAccount { get; set; }

    [JsonPropertyName("transaction_type")]
    public string? TransactionType { get; set; }
}
