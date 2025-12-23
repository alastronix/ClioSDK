using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the ActivityDescriptions endpoint of the Clio API
    /// </summary>
    public class ActivityDescriptionsClient : BaseClient
    {
        public ActivityDescriptionsClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all ActivityDescriptions
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<ActivityDescriptions>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<ActivityDescriptions>>("activity_descriptions.json", options);
        }

        /// <summary>
        /// Return the data for a single ActivityDescriptions
        /// </summary>
        public async Task<ApiResponse<ActivityDescriptions>> GetByIdAsync(int id)
        {
            return await GetByIdAsync<ActivityDescriptions>("activity_descriptions/{id}.json", id);
        }

        /// <summary>
        /// Create a new ActivityDescriptions
        /// </summary>
        public async Task<ApiResponse<ActivityDescriptions>> CreateAsync(ActivityDescriptionsRequest request)
        {
            return await CreateAsync<ActivityDescriptionsRequest, ActivityDescriptions>("activity_descriptions.json", request);
        }

        /// <summary>
        /// Update a single ActivityDescriptions
        /// </summary>
        public async Task<ApiResponse<ActivityDescriptions>> UpdateAsync(ActivityDescriptionsRequest request)
        {
            return await UpdateAsync<ActivityDescriptionsRequest, ActivityDescriptions>("activity_descriptions/{id}.json", request);
        }

        /// <summary>
        /// Delete a single ActivityDescriptions
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync<int>("activity_descriptions/{id}.json", id);
        }
    }
}