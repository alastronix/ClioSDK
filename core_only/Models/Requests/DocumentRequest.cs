using System.Text.Json.Serialization;

namespace ClioSDK.Models.Requests;

public class DocumentRequest
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("matter")]
    public MatterReferenceRequest? Matter { get; set; }

    [JsonPropertyName("client")]
    public ContactReferenceRequest? Client { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("document_category")]
    public DocumentCategoryReferenceRequest? DocumentCategory { get; set; }
}

public class DocumentCategoryReferenceRequest
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
}