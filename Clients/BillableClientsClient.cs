using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the BillableClients endpoint of the Clio API
    /// </summary>
    public class BillableClientsClient : BaseClient
    {
        public BillableClientsClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all BillableClients
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<BillableClients>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<BillableClients>>("billableclients.json", options);
        }

        /// <summary>
        /// Return the data for a single BillableClients
        /// </summary>
        public async Task<ApiResponse<BillableClients>> GetByIdAsync(int id)
        {
            return await GetByIdAsync<BillableClients>("billableclients/{id}.json", id);
        }

        /// <summary>
        /// Create a new BillableClients
        /// </summary>
        public async Task<ApiResponse<BillableClients>> CreateAsync(BillableClientsRequest request)
        {
            return await CreateAsync<BillableClientsRequest, BillableClients>("billableclients.json", request);
        }

        /// <summary>
        /// Update a single BillableClients
        /// </summary>
        public async Task<ApiResponse<BillableClients>> UpdateAsync(BillableClientsRequest request)
        {
            return await UpdateAsync<BillableClientsRequest, BillableClients>("billableclients/{id}.json", request);
        }

        /// <summary>
        /// Delete a single BillableClients
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync<int>("billableclients/{id}.json", id);
        }
    }
}