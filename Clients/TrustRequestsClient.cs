using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the TrustRequests endpoint of the Clio API
    /// </summary>
    public class TrustRequestsClient : BaseClient
    {
        public TrustRequestsClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all TrustRequests
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<TrustRequests>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<TrustRequests>>("trust_requests.json", options);
        }

        /// <summary>
        /// Return the data for a single TrustRequests
        /// </summary>
        public async Task<ApiResponse<TrustRequests>> GetByIdAsync(int id)
        {
            return await GetByIdAsync<TrustRequests>("trust_requests/{id}.json", id);
        }

        /// <summary>
        /// Create a new TrustRequests
        /// </summary>
        public async Task<ApiResponse<TrustRequests>> CreateAsync(TrustRequestsRequest request)
        {
            return await CreateAsync<TrustRequestsRequest, TrustRequests>("trust_requests.json", request);
        }

        /// <summary>
        /// Update a single TrustRequests
        /// </summary>
        public async Task<ApiResponse<TrustRequests>> UpdateAsync(TrustRequestsRequest request)
        {
            return await UpdateAsync<TrustRequestsRequest, TrustRequests>("trust_requests/{id}.json", request);
        }

        /// <summary>
        /// Delete a single TrustRequests
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync<int>("trust_requests/{id}.json", id);
        }
    }
}