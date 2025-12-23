using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the Grants endpoint of the Clio API
    /// </summary>
    public class GrantsClient : BaseClient
    {
        public GrantsClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all Grants
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<Grants>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<Grants>>("grants.json", options);
        }

        /// <summary>
        /// Return the data for a single Grants
        /// </summary>
        public async Task<ApiResponse<Grants>> GetByIdAsync(int id)
        {
            return await GetByIdAsync<Grants>("grants/{id}.json", id);
        }

        /// <summary>
        /// Create a new Grants
        /// </summary>
        public async Task<ApiResponse<Grants>> CreateAsync(GrantsRequest request)
        {
            return await CreateAsync<GrantsRequest, Grants>("grants.json", request);
        }

        /// <summary>
        /// Update a single Grants
        /// </summary>
        public async Task<ApiResponse<Grants>> UpdateAsync(GrantsRequest request)
        {
            return await UpdateAsync<GrantsRequest, Grants>("grants/{id}.json", request);
        }

        /// <summary>
        /// Delete a single Grants
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync<int>("grants/{id}.json", id);
        }
    }
}