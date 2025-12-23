using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the EventMetrics endpoint of the Clio API
    /// </summary>
    public class EventMetricsClient : BaseClient
    {
        public EventMetricsClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all EventMetrics
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<EventMetrics>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<EventMetrics>>("event_metrics.json", options);
        }

        /// <summary>
        /// Return the data for a single EventMetrics
        /// </summary>
        public async Task<ApiResponse<EventMetrics>> GetByIdAsync(int id)
        {
            return await GetByIdAsync<EventMetrics>("event_metrics/{id}.json", id);
        }

        /// <summary>
        /// Create a new EventMetrics
        /// </summary>
        public async Task<ApiResponse<EventMetrics>> CreateAsync(EventMetricsRequest request)
        {
            return await CreateAsync<EventMetricsRequest, EventMetrics>("event_metrics.json", request);
        }

        /// <summary>
        /// Update a single EventMetrics
        /// </summary>
        public async Task<ApiResponse<EventMetrics>> UpdateAsync(EventMetricsRequest request)
        {
            return await UpdateAsync<EventMetricsRequest, EventMetrics>("event_metrics/{id}.json", request);
        }

        /// <summary>
        /// Delete a single EventMetrics
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync<int>("event_metrics/{id}.json", id);
        }
    }
}