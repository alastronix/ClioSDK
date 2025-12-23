using System.Text.Json.Serialization;
using ClioSDK.Core;

namespace ClioSDK.Models;

public class Document : BaseModel
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("size")]
    public long? Size { get; set; }

    [JsonPropertyName("content_type")]
    public string? ContentType { get; set; }

    [JsonPropertyName("url")]
    public string? Url { get; set; }

    [JsonPropertyName("document_category")]
    public DocumentCategoryReference? DocumentCategory { get; set; }

    [JsonPropertyName("matter")]
    public MatterReference? Matter { get; set; }

    [JsonPropertyName("contact")]
    public ContactReference? Contact { get; set; }
}

public class DocumentCategoryReference
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}

public class DocumentRequest
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("document_category")]
    public DocumentCategoryReferenceRequest? DocumentCategory { get; set; }

    [JsonPropertyName("matter")]
    public MatterReferenceRequest? Matter { get; set; }

    [JsonPropertyName("contact")]
    public ContactReferenceRequest? Contact { get; set; }
}

public class DocumentCategoryReferenceRequest
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
}