using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the TrustLineItems endpoint of the Clio API
    /// </summary>
    public class TrustLineItemsClient : BaseClient
    {
        public TrustLineItemsClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all TrustLineItems
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<TrustLineItems>>> GetAsync(
            Dictionary<string, object> parameters = null)
        {
            return await GetAsync<PaginatedResponse<TrustLineItems>>("trust_line_items.json", parameters);
        }

        /// <summary>
        /// Return the data for a single TrustLineItems
        /// </summary>
        public async Task<ApiResponse<TrustLineItems>> GetByIdAsync(int id)
        {
            return await GetAsync<TrustLineItems>("trust_line_items/{id}.json", id);
        }

        /// <summary>
        /// Create a new TrustLineItems
        /// </summary>
        public async Task<ApiResponse<TrustLineItems>> CreateAsync(TrustLineItemsRequest request)
        {
            return await CreateAsync<TrustLineItemsRequest, TrustLineItems>("trust_line_items.json", request);
        }

        /// <summary>
        /// Update a single TrustLineItems
        /// </summary>
        public async Task<ApiResponse<TrustLineItems>> UpdateAsync(int id, TrustLineItemsRequest request)
        {
            return await UpdateAsync<TrustLineItemsRequest, TrustLineItems>("trust_line_items/{id}.json", id, request);
        }

        /// <summary>
        /// Delete a single TrustLineItems
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync("trust_line_items/{id}.json", id);
        }
    }
}