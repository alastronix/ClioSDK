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
        public async Task<ApiResponse<PaginatedResponse<BillingSettings>>> GetAsync(
            Dictionary<string, object> parameters = null)
        {
            return await GetAsync<PaginatedResponse<BillingSettings>>("billing_settings.json", parameters);
        }

        /// <summary>
        /// Return the data for a single BillingSettings
        /// </summary>
        public async Task<ApiResponse<BillingSettings>> GetByIdAsync(int id)
        {
            return await GetAsync<BillingSettings>("billing_settings/{id}.json", id);
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
        public async Task<ApiResponse<BillingSettings>> UpdateAsync(int id, BillingSettingsRequest request)
        {
            return await UpdateAsync<BillingSettingsRequest, BillingSettings>("billing_settings/{id}.json", id, request);
        }

        /// <summary>
        /// Delete a single BillingSettings
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync("billing_settings/{id}.json", id);
        }
    }
}