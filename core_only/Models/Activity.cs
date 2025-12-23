using System.Text.Json.Serialization;
using ClioSDK.Core;

namespace ClioSDK.Models;

public class Activity : BaseModel
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("date")]
    public DateTime? Date { get; set; }

    [JsonPropertyName("quantity")]
    public decimal? Quantity { get; set; }

    [JsonPropertyName("price")]
    public decimal? Price { get; set; }

    [JsonPropertyName("total")]
    public decimal? Total { get; set; }

    [JsonPropertyName("billable")]
    public bool? Billable { get; set; }

    [JsonPropertyName("billed")]
    public bool? Billed { get; set; }

    [JsonPropertyName("time_entry")]
    public bool? TimeEntry { get; set; }

    [JsonPropertyName("expense")]
    public bool? Expense { get; set; }

    [JsonPropertyName("note")]
    public bool? Note { get; set; }

    [JsonPropertyName("user")]
    public UserReference? User { get; set; }

    [JsonPropertyName("matter")]
    public MatterReference? Matter { get; set; }

    [JsonPropertyName("contact")]
    public ContactReference? Contact { get; set; }

    [JsonPropertyName("activity_description")]
    public ActivityDescriptionReference? ActivityDescription { get; set; }
}

public class UserReference
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}

public class MatterReference
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("display_number")]
    public string? DisplayNumber { get; set; }
}

public class ContactReference
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}

public class ActivityDescriptionReference
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}

public class ActivityRequest
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("date")]
    public DateTime? Date { get; set; }

    [JsonPropertyName("quantity")]
    public decimal? Quantity { get; set; }

    [JsonPropertyName("price")]
    public decimal? Price { get; set; }

    [JsonPropertyName("billable")]
    public bool? Billable { get; set; }

    [JsonPropertyName("time_entry")]
    public bool? TimeEntry { get; set; }

    [JsonPropertyName("user")]
    public UserReferenceRequest? User { get; set; }

    [JsonPropertyName("matter")]
    public MatterReferenceRequest? Matter { get; set; }

    [JsonPropertyName("note_details")]
    public string? NoteDetails { get; set; }
}

public class UserReferenceRequest
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
}

public class MatterReferenceRequest
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
}