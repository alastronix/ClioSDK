using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the MyEvents endpoint of the Clio API
    /// </summary>
    public class MyEventsClient : BaseClient
    {
        public MyEventsClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all MyEvents
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<MyEvents>>> GetAsync(
            Dictionary<string, object> parameters = null)
        {
            return await GetAsync<PaginatedResponse<MyEvents>>("my_events.json", parameters);
        }

        /// <summary>
        /// Return the data for a single MyEvents
        /// </summary>
        public async Task<ApiResponse<MyEvents>> GetByIdAsync(int id)
        {
            return await GetAsync<MyEvents>("my_events/{id}.json", id);
        }

        /// <summary>
        /// Create a new MyEvents
        /// </summary>
        public async Task<ApiResponse<MyEvents>> CreateAsync(MyEventsRequest request)
        {
            return await CreateAsync<MyEventsRequest, MyEvents>("my_events.json", request);
        }

        /// <summary>
        /// Update a single MyEvents
        /// </summary>
        public async Task<ApiResponse<MyEvents>> UpdateAsync(int id, MyEventsRequest request)
        {
            return await UpdateAsync<MyEventsRequest, MyEvents>("my_events/{id}.json", id, request);
        }

        /// <summary>
        /// Delete a single MyEvents
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync("my_events/{id}.json", id);
        }
    }
}