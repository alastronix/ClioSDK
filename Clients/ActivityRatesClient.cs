using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the ActivityRates endpoint of the Clio API
    /// </summary>
    public class ActivityRatesClient : BaseClient
    {
        public ActivityRatesClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all ActivityRates
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<ActivityRates>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<ActivityRates>>("activity_rates.json", options);
        }

        /// <summary>
        /// Create a new ActivityRates
        /// </summary>
        public async Task<ApiResponse<ActivityRates>> CreateAsync(ActivityRatesRequest request)
        {
            return await CreateAsync<ActivityRatesRequest, ActivityRates>("activity_rates.json", request);
        }

        /// <summary>
        /// Update a single ActivityRates
        /// </summary>
        public async Task<ApiResponse<ActivityRates>> UpdateAsync(ActivityRatesRequest request)
        {
            return await UpdateAsync<ActivityRatesRequest, ActivityRates>("activity_rates/{id}.json", request);
        }

        /// <summary>
        /// Delete a single ActivityRates
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            await base.DeleteAsync("activity_rates/{id}.json");
                return new ApiResponse<object> { Data = default! };
        }
    }
}