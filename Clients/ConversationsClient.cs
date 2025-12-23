using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the Conversations endpoint of the Clio API
    /// </summary>
    public class ConversationsClient : BaseClient
    {
        public ConversationsClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all Conversations
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<Conversations>>> GetAsync(
            Dictionary<string, object> parameters = null)
        {
            return await GetAsync<PaginatedResponse<Conversations>>("conversations.json", parameters);
        }

        /// <summary>
        /// Return the data for a single Conversations
        /// </summary>
        public async Task<ApiResponse<Conversations>> GetByIdAsync(int id)
        {
            return await GetAsync<Conversations>("conversations/{id}.json", id);
        }

        /// <summary>
        /// Create a new Conversations
        /// </summary>
        public async Task<ApiResponse<Conversations>> CreateAsync(ConversationsRequest request)
        {
            return await CreateAsync<ConversationsRequest, Conversations>("conversations.json", request);
        }

        /// <summary>
        /// Update a single Conversations
        /// </summary>
        public async Task<ApiResponse<Conversations>> UpdateAsync(int id, ConversationsRequest request)
        {
            return await UpdateAsync<ConversationsRequest, Conversations>("conversations/{id}.json", id, request);
        }

        /// <summary>
        /// Delete a single Conversations
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync("conversations/{id}.json", id);
        }
    }
}