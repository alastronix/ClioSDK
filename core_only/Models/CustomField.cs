using System.Text.Json.Serialization;
using ClioSDK.Core;

namespace ClioSDK.Models;

public class CustomField : BaseModel
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("field_type")]
    public string? FieldType { get; set; }

    [JsonPropertyName("data_type")]
    public string? DataType { get; set; }

    [JsonPropertyName("options")]
    public List<string>? Options { get; set; }

    [JsonPropertyName("required")]
    public bool? Required { get; set; }

    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }
}

public class CustomFieldSet : BaseModel
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("target_type")]
    public string? TargetType { get; set; }

    [JsonPropertyName("custom_fields")]
    public List<CustomField>? CustomFields { get; set; }
}