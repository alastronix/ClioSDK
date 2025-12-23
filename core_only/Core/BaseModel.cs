using System.Text.Json.Serialization;

namespace ClioSDK.Core;

public abstract class BaseModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }
}

public class PaginatedResponse<T>
{
    [JsonPropertyName("data")]
    public List<T> Data { get; set; } = new();

    [JsonPropertyName("meta")]
    public Meta Meta { get; set; } = new();
}

public class ApiResponse<T>
{
    [JsonPropertyName("data")]
    public T Data { get; set; } = default!;

    [JsonPropertyName("meta")]
    public Meta Meta { get; set; } = new();
}

public class Meta
{
    [JsonPropertyName("pagination")]
    public Pagination? Pagination { get; set; }
}

public class Pagination
{
    [JsonPropertyName("total_count")]
    public int TotalCount { get; set; }

    [JsonPropertyName("page")]
    public int Page { get; set; }

    [JsonPropertyName("per_page")]
    public int PerPage { get; set; }

    [JsonPropertyName("has_more")]
    public bool HasMore { get; set; }
}

public class QueryOptions
{
    public int? Limit { get; set; }
    public int? Offset { get; set; }
    public string? Order { get; set; }
    public string? Fields { get; set; }
    public Dictionary<string, object>? Query { get; set; }
}