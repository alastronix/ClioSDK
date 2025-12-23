using System;
using System.Text.Json.Serialization;
using ClioSDK.Core;

namespace ClioSDK.Models
{
    /// <summary>
    /// Represents a MyEvents in the Clio API
    /// </summary>
    public class MyEvents : BaseModel
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
    /// Request model for creating/updating MyEvents
    /// </summary>
    public class MyEventsRequest
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