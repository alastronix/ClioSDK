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
        public async Task<ApiResponse<PaginatedResponse<MyEvents>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<MyEvents>>("my_events.json", options);
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
        public async Task<ApiResponse<MyEvents>> UpdateAsync(MyEventsRequest request)
        {
            return await UpdateAsync<MyEventsRequest, MyEvents>("my_events/{id}.json", request);
        }

        /// <summary>
        /// Delete a single MyEvents
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            await base.DeleteAsync("my_events/{id}.json");
                return new ApiResponse<object> { Data = default! };
        }
    }
}