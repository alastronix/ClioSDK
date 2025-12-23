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
        public async Task<ApiResponse<PaginatedResponse<GrantFundingSources>>> GetAsync(
            Dictionary<string, object> parameters = null)
        {
            return await GetAsync<PaginatedResponse<GrantFundingSources>>("grant_funding_sources.json", parameters);
        }

        /// <summary>
        /// Return the data for a single GrantFundingSources
        /// </summary>
        public async Task<ApiResponse<GrantFundingSources>> GetByIdAsync(int id)
        {
            return await GetAsync<GrantFundingSources>("grant_funding_sources/{id}.json", id);
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
        public async Task<ApiResponse<GrantFundingSources>> UpdateAsync(int id, GrantFundingSourcesRequest request)
        {
            return await UpdateAsync<GrantFundingSourcesRequest, GrantFundingSources>("grant_funding_sources/{id}.json", id, request);
        }

        /// <summary>
        /// Delete a single GrantFundingSources
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync("grant_funding_sources/{id}.json", id);
        }
    }
}