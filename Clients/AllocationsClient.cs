using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the Allocations endpoint of the Clio API
    /// </summary>
    public class AllocationsClient : BaseClient
    {
        public AllocationsClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all Allocations
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<Allocations>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<Allocations>>("allocations.json", options);
        }

        /// <summary>
        /// Return the data for a single Allocations
        /// </summary>
        public async Task<ApiResponse<Allocations>> GetByIdAsync(int id)
        {
            return await GetByIdAsync<Allocations>("allocations/{id}.json", id);
        }

        /// <summary>
        /// Create a new Allocations
        /// </summary>
        public async Task<ApiResponse<Allocations>> CreateAsync(AllocationsRequest request)
        {
            return await CreateAsync<AllocationsRequest, Allocations>("allocations.json", request);
        }

        /// <summary>
        /// Update a single Allocations
        /// </summary>
        public async Task<ApiResponse<Allocations>> UpdateAsync(AllocationsRequest request)
        {
            return await UpdateAsync<AllocationsRequest, Allocations>("allocations/{id}.json", request);
        }

        /// <summary>
        /// Delete a single Allocations
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync<int>("allocations/{id}.json", id);
        }
    }
}