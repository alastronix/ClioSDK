using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the GrantFundingSources endpoint of the Clio API
    /// </summary>
    public class GrantFundingSourcesClient : BaseClient
    {
        public GrantFundingSourcesClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all GrantFundingSources
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<GrantFundingSources>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<GrantFundingSources>>("grant_funding_sources.json", options);
        }

        /// <summary>
        /// Create a new GrantFundingSources
        /// </summary>
        public async Task<ApiResponse<GrantFundingSources>> CreateAsync(GrantFundingSourcesRequest request)
        {
            return await CreateAsync<GrantFundingSourcesRequest, GrantFundingSources>("grant_funding_sources.json", request);
        }

        /// <summary>
        /// Update a single GrantFundingSources
        /// </summary>
        public async Task<ApiResponse<GrantFundingSources>> UpdateAsync(GrantFundingSourcesRequest request)
        {
            return await UpdateAsync<GrantFundingSourcesRequest, GrantFundingSources>("grant_funding_sources/{id}.json", request);
        }

        /// <summary>
        /// Delete a single GrantFundingSources
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            await base.DeleteAsync("grant_funding_sources/{id}.json");
                return new ApiResponse<object> { Data = default! };
        }
    }
}