using System.Text.Json.Serialization;
using ClioSDK.Core;

namespace ClioSDK.Models;

public class CalendarEntrie : BaseModel
{
    [JsonPropertyName("summary")]
    public string? summary { get; set; }
    [JsonPropertyName("description")]
    public string? description { get; set; }
    [JsonPropertyName("start_at")]
    public DateTime? start_at { get; set; }
    [JsonPropertyName("end_at")]
    public DateTime? end_at { get; set; }
    [JsonPropertyName("all_day")]
    public bool? all_day { get; set; }
    [JsonPropertyName("calendar")]
    public string? calendar { get; set; }
}

public class CalendarEntrieRequest
{
    [JsonPropertyName("summary")]
    public string? summary { get; set; }
    [JsonPropertyName("description")]
    public string? description { get; set; }
    [JsonPropertyName("start_at")]
    public DateTime? start_at { get; set; }
    [JsonPropertyName("end_at")]
    public DateTime? end_at { get; set; }
    [JsonPropertyName("all_day")]
    public bool? all_day { get; set; }
    [JsonPropertyName("calendar")]
    public string? calendar { get; set; }
}