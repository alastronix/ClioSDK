using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the CustomActions endpoint of the Clio API
    /// </summary>
    public class CustomActionsClient : BaseClient
    {
        public CustomActionsClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all CustomActions
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<CustomActions>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<CustomActions>>("customactions.json", options);
        }

        /// <summary>
        /// Return the data for a single CustomActions
        /// </summary>
        public async Task<ApiResponse<CustomActions>> GetByIdAsync(int id)
        {
            return await GetByIdAsync("customactions/{id}.json", id);
        }

        /// <summary>
        /// Create a new CustomActions
        /// </summary>
        public async Task<ApiResponse<CustomActions>> CreateAsync(CustomActionsRequest request)
        {
            return await CreateAsync<CustomActionsRequest, CustomActions>("customactions.json", request);
        }

        /// <summary>
        /// Update a single CustomActions
        /// </summary>
        public async Task<ApiResponse<CustomActions>> UpdateAsync(CustomActionsRequest request)
        {
            return await UpdateAsync<CustomActionsRequest, CustomActions>("customactions/{id}.json", request);
        }

        /// <summary>
        /// Delete a single CustomActions
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync("customactions/{id}.json", id);
        }
    }
}