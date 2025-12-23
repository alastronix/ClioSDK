using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the CalendarVisibilities endpoint of the Clio API
    /// </summary>
    public class CalendarVisibilitiesClient : BaseClient
    {
        public CalendarVisibilitiesClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all CalendarVisibilities
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<CalendarVisibilities>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<CalendarVisibilities>>("calendar_visibilities.json", options);
        }

        /// <summary>
        /// Return the data for a single CalendarVisibilities
        /// </summary>
        public async Task<ApiResponse<CalendarVisibilities>> GetByIdAsync(int id)
        {
            return await GetByIdAsync<CalendarVisibilities>("calendar_visibilities/{id}.json", id);
        }

        /// <summary>
        /// Create a new CalendarVisibilities
        /// </summary>
        public async Task<ApiResponse<CalendarVisibilities>> CreateAsync(CalendarVisibilitiesRequest request)
        {
            return await CreateAsync<CalendarVisibilitiesRequest, CalendarVisibilities>("calendar_visibilities.json", request);
        }

        /// <summary>
        /// Update a single CalendarVisibilities
        /// </summary>
        public async Task<ApiResponse<CalendarVisibilities>> UpdateAsync(CalendarVisibilitiesRequest request)
        {
            return await UpdateAsync<CalendarVisibilitiesRequest, CalendarVisibilities>("calendar_visibilities/{id}.json", request);
        }

        /// <summary>
        /// Delete a single CalendarVisibilities
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync<int>("calendar_visibilities/{id}.json", id);
        }
    }
}