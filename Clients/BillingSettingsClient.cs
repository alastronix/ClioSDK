using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the BillingSettings endpoint of the Clio API
    /// </summary>
    public class BillingSettingsClient : BaseClient
    {
        public BillingSettingsClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all BillingSettings
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<BillingSettings>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<BillingSettings>>("billing_settings.json", options);
        }

        /// <summary>
        /// Create a new BillingSettings
        /// </summary>
        public async Task<ApiResponse<BillingSettings>> CreateAsync(BillingSettingsRequest request)
        {
            return await CreateAsync<BillingSettingsRequest, BillingSettings>("billing_settings.json", request);
        }

        /// <summary>
        /// Update a single BillingSettings
        /// </summary>
        public async Task<ApiResponse<BillingSettings>> UpdateAsync(BillingSettingsRequest request)
        {
            return await UpdateAsync<BillingSettingsRequest, BillingSettings>("billing_settings/{id}.json", request);
        }

        /// <summary>
        /// Delete a single BillingSettings
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            await base.DeleteAsync("billing_settings/{id}.json");
                return new ApiResponse<object> { Data = default! };
        }
    }
}