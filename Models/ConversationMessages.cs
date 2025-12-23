using System;
using System.Text.Json.Serialization;
using ClioSDK.Core;

namespace ClioSDK.Models
{
    /// <summary>
    /// Represents a ConversationMessages in the Clio API
    /// </summary>
    public class ConversationMessages : BaseModel
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
    /// Request model for creating/updating ConversationMessages
    /// </summary>
    public class ConversationMessagesRequest
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