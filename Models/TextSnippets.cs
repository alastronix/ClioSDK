using System;
using System.Text.Json.Serialization;
using ClioSDK.Core;

namespace ClioSDK.Models
{
    /// <summary>
    /// Represents a TextSnippets in the Clio API
    /// </summary>
    public class TextSnippets : BaseModel
    {
        // TODO: Add specific properties based on Clio API documentation
        // Common properties are inherited from BaseModel (id, etag, created_at, updated_at)
        
        /// <summary>
        /// Example property - replace with actual properties from API documentation
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// Example property - replace with actual properties from API documentation
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }

    /// <summary>
    /// Request model for creating/updating TextSnippets
    /// </summary>
    public class TextSnippetsRequest
    {
        // TODO: Add request properties based on Clio API documentation
        
        /// <summary>
        /// Example property - replace with actual properties from API documentation
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        /// <summary>
        /// Example property - replace with actual properties from API documentation
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}