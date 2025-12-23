using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the BillableMatters endpoint of the Clio API
    /// </summary>
    public class BillableMattersClient : BaseClient
    {
        public BillableMattersClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all BillableMatters
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<BillableMatters>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<BillableMatters>>("billablematters.json", options);
        }

        /// <summary>
        /// Return the data for a single BillableMatters
        /// </summary>
        public async Task<ApiResponse<BillableMatters>> GetByIdAsync(int id)
        {
            return await GetByIdAsync("billablematters/{id}.json", id);
        }

        /// <summary>
        /// Create a new BillableMatters
        /// </summary>
        public async Task<ApiResponse<BillableMatters>> CreateAsync(BillableMattersRequest request)
        {
            return await CreateAsync<BillableMattersRequest, BillableMatters>("billablematters.json", request);
        }

        /// <summary>
        /// Update a single BillableMatters
        /// </summary>
        public async Task<ApiResponse<BillableMatters>> UpdateAsync(BillableMattersRequest request)
        {
            return await UpdateAsync<BillableMattersRequest, BillableMatters>("billablematters/{id}.json", request);
        }

        /// <summary>
        /// Delete a single BillableMatters
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync("billablematters/{id}.json", id);
        }
    }
}