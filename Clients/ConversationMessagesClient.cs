using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the ConversationMessages endpoint of the Clio API
    /// </summary>
    public class ConversationMessagesClient : BaseClient
    {
        public ConversationMessagesClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all ConversationMessages
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<ConversationMessages>>> GetAsync(
            Dictionary<string, object> parameters = null)
        {
            return await GetAsync<PaginatedResponse<ConversationMessages>>("conversation_messages.json", parameters);
        }

        /// <summary>
        /// Return the data for a single ConversationMessages
        /// </summary>
        public async Task<ApiResponse<ConversationMessages>> GetByIdAsync(int id)
        {
            return await GetAsync<ConversationMessages>("conversation_messages/{id}.json", id);
        }

        /// <summary>
        /// Create a new ConversationMessages
        /// </summary>
        public async Task<ApiResponse<ConversationMessages>> CreateAsync(ConversationMessagesRequest request)
        {
            return await CreateAsync<ConversationMessagesRequest, ConversationMessages>("conversation_messages.json", request);
        }

        /// <summary>
        /// Update a single ConversationMessages
        /// </summary>
        public async Task<ApiResponse<ConversationMessages>> UpdateAsync(int id, ConversationMessagesRequest request)
        {
            return await UpdateAsync<ConversationMessagesRequest, ConversationMessages>("conversation_messages/{id}.json", id, request);
        }

        /// <summary>
        /// Delete a single ConversationMessages
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync("conversation_messages/{id}.json", id);
        }
    }
}