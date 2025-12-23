using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the Comments endpoint of the Clio API
    /// </summary>
    public class CommentsClient : BaseClient
    {
        public CommentsClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all Comments
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<Comments>>> GetAsync(
            Dictionary<string, object> parameters = null)
        {
            return await GetAsync<PaginatedResponse<Comments>>("comments.json", parameters);
        }

        /// <summary>
        /// Return the data for a single Comments
        /// </summary>
        public async Task<ApiResponse<Comments>> GetByIdAsync(int id)
        {
            return await GetAsync<Comments>("comments/{id}.json", id);
        }

        /// <summary>
        /// Create a new Comments
        /// </summary>
        public async Task<ApiResponse<Comments>> CreateAsync(CommentsRequest request)
        {
            return await CreateAsync<CommentsRequest, Comments>("comments.json", request);
        }

        /// <summary>
        /// Update a single Comments
        /// </summary>
        public async Task<ApiResponse<Comments>> UpdateAsync(int id, CommentsRequest request)
        {
            return await UpdateAsync<CommentsRequest, Comments>("comments/{id}.json", id, request);
        }

        /// <summary>
        /// Delete a single Comments
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync("comments/{id}.json", id);
        }
    }
}