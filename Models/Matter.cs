using System.Text.Json.Serialization;
using ClioSDK.Core;

namespace ClioSDK.Models;

public class Matter : BaseModel
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("display_number")]
    public string? DisplayNumber { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("billing_method")]
    public string? BillingMethod { get; set; }

    [JsonPropertyName("open_date")]
    public DateTime? OpenDate { get; set; }

    [JsonPropertyName("close_date")]
    public DateTime? CloseDate { get; set; }

    [JsonPropertyName("client")]
    public ContactReference? Client { get; set; }

    [JsonPropertyName("practice_area")]
    public PracticeAreaReference? PracticeArea { get; set; }

    [JsonPropertyName("assignee")]
    public UserReference? Assignee { get; set; }

    [JsonPropertyName("custom_field_values")]
    public List<CustomFieldValue>? CustomFieldValues { get; set; }
}

public class PracticeAreaReference
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}

public class CustomFieldValue
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("custom_field")]
    public CustomFieldReference? CustomField { get; set; }

    [JsonPropertyName("value")]
    public object? Value { get; set; }
}

public class CustomFieldReference
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}

public class MatterRequest
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("display_number")]
    public string? DisplayNumber { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("billing_method")]
    public string? BillingMethod { get; set; }

    [JsonPropertyName("open_date")]
    public DateTime? OpenDate { get; set; }

    [JsonPropertyName("client")]
    public ContactReferenceRequest? Client { get; set; }

    [JsonPropertyName("practice_area")]
    public PracticeAreaReferenceRequest? PracticeArea { get; set; }

    [JsonPropertyName("assignee")]
    public UserReferenceRequest? Assignee { get; set; }
}

public class ContactReferenceRequest
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
}

public class PracticeAreaReferenceRequest
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
}