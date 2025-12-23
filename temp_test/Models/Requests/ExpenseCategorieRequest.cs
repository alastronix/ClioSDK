using System.Text.Json.Serialization;

namespace ClioSDK.Models.Requests;

public class ExpenseCategorieRequest
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("default_rate")]
    public decimal? DefaultRate { get; set; }
}
