using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the UtbmsSets endpoint of the Clio API
    /// </summary>
    public class UtbmsSetsClient : BaseClient
    {
        public UtbmsSetsClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all UtbmsSets
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<UtbmsSets>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<UtbmsSets>>("utbmssets.json", options);
        }

        /// <summary>
        /// Return the data for a single UtbmsSets
        /// </summary>
        public async Task<ApiResponse<UtbmsSets>> GetByIdAsync(int id)
        {
            return await GetByIdAsync<UtbmsSets>("utbmssets/{id}.json", id);
        }

        /// <summary>
        /// Create a new UtbmsSets
        /// </summary>
        public async Task<ApiResponse<UtbmsSets>> CreateAsync(UtbmsSetsRequest request)
        {
            return await CreateAsync<UtbmsSetsRequest, UtbmsSets>("utbmssets.json", request);
        }

        /// <summary>
        /// Update a single UtbmsSets
        /// </summary>
        public async Task<ApiResponse<UtbmsSets>> UpdateAsync(UtbmsSetsRequest request)
        {
            return await UpdateAsync<UtbmsSetsRequest, UtbmsSets>("utbmssets/{id}.json", request);
        }

        /// <summary>
        /// Delete a single UtbmsSets
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync<int>("utbmssets/{id}.json", id);
        }
    }
}