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
        public async Task<ApiResponse<PaginatedResponse<Conversations>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<Conversations>>("conversations.json", options);
        }

        /// <summary>
        /// Return the data for a single Conversations
        /// </summary>
        public async Task<ApiResponse<Conversations>> GetByIdAsync(int id)
        {
            return await GetByIdAsync("conversations/{id}.json", id);
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
        public async Task<ApiResponse<Conversations>> UpdateAsync(ConversationsRequest request)
        {
            return await UpdateAsync<ConversationsRequest, Conversations>("conversations/{id}.json", request);
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