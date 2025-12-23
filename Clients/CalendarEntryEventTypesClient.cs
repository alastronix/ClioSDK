using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the CalendarEntryEventTypes endpoint of the Clio API
    /// </summary>
    public class CalendarEntryEventTypesClient : BaseClient
    {
        public CalendarEntryEventTypesClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all CalendarEntryEventTypes
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<CalendarEntryEventTypes>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<CalendarEntryEventTypes>>("calendar_entry_event_types.json", options);
        }

        /// <summary>
        /// Return the data for a single CalendarEntryEventTypes
        /// </summary>
        public async Task<ApiResponse<CalendarEntryEventTypes>> GetByIdAsync(int id)
        {
            return await GetByIdAsync("calendar_entry_event_types/{id}.json", id);
        }

        /// <summary>
        /// Create a new CalendarEntryEventTypes
        /// </summary>
        public async Task<ApiResponse<CalendarEntryEventTypes>> CreateAsync(CalendarEntryEventTypesRequest request)
        {
            return await CreateAsync<CalendarEntryEventTypesRequest, CalendarEntryEventTypes>("calendar_entry_event_types.json", request);
        }

        /// <summary>
        /// Update a single CalendarEntryEventTypes
        /// </summary>
        public async Task<ApiResponse<CalendarEntryEventTypes>> UpdateAsync(CalendarEntryEventTypesRequest request)
        {
            return await UpdateAsync<CalendarEntryEventTypesRequest, CalendarEntryEventTypes>("calendar_entry_event_types/{id}.json", request);
        }

        /// <summary>
        /// Delete a single CalendarEntryEventTypes
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync("calendar_entry_event_types/{id}.json", id);
        }
    }
}