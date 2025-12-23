using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the OutstandingClientBalances endpoint of the Clio API
    /// </summary>
    public class OutstandingClientBalancesClient : BaseClient
    {
        public OutstandingClientBalancesClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all OutstandingClientBalances
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<OutstandingClientBalances>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<OutstandingClientBalances>>("outstandingclientbalances.json", options);
        }

        /// <summary>
        /// Return the data for a single OutstandingClientBalances
        /// </summary>
        public async Task<ApiResponse<OutstandingClientBalances>> GetByIdAsync(int id)
        {
            return await GetByIdAsync("outstandingclientbalances/{id}.json", id);
        }

        /// <summary>
        /// Create a new OutstandingClientBalances
        /// </summary>
        public async Task<ApiResponse<OutstandingClientBalances>> CreateAsync(OutstandingClientBalancesRequest request)
        {
            return await CreateAsync<OutstandingClientBalancesRequest, OutstandingClientBalances>("outstandingclientbalances.json", request);
        }

        /// <summary>
        /// Update a single OutstandingClientBalances
        /// </summary>
        public async Task<ApiResponse<OutstandingClientBalances>> UpdateAsync(OutstandingClientBalancesRequest request)
        {
            return await UpdateAsync<OutstandingClientBalancesRequest, OutstandingClientBalances>("outstandingclientbalances/{id}.json", request);
        }

        /// <summary>
        /// Delete a single OutstandingClientBalances
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync("outstandingclientbalances/{id}.json", id);
        }
    }
}