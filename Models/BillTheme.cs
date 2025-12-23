using System.Text.Json.Serialization;
using ClioSDK.Core;

namespace ClioSDK.Models;

public class BillTheme : BaseModel
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("default")]
    public bool? Default { get; set; }

    [JsonPropertyName("logo_url")]
    public string? LogoUrl { get; set; }

    [JsonPropertyName("firm_name")]
    public string? FirmName { get; set; }

    [JsonPropertyName("address")]
    public string? Address { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("website")]
    public string? Website { get; set; }
}

public class BillThemeRequest
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("default")]
    public bool? Default { get; set; }

    [JsonPropertyName("logo_url")]
    public string? LogoUrl { get; set; }

    [JsonPropertyName("firm_name")]
    public string? FirmName { get; set; }

    [JsonPropertyName("address")]
    public string? Address { get; set; }

    [JsonPropertyName("phone")]
    public string? Phone { get; set; }

    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [JsonPropertyName("website")]
    public string? Website { get; set; }
}