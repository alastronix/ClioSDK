using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the Reminders endpoint of the Clio API
    /// </summary>
    public class RemindersClient : BaseClient
    {
        public RemindersClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all Reminders
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<Reminders>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<Reminders>>("reminders.json", options);
        }

        /// <summary>
        /// Return the data for a single Reminders
        /// </summary>
        public async Task<ApiResponse<Reminders>> GetByIdAsync(int id)
        {
            return await GetByIdAsync("reminders/{id}.json", id);
        }

        /// <summary>
        /// Create a new Reminders
        /// </summary>
        public async Task<ApiResponse<Reminders>> CreateAsync(RemindersRequest request)
        {
            return await CreateAsync<RemindersRequest, Reminders>("reminders.json", request);
        }

        /// <summary>
        /// Update a single Reminders
        /// </summary>
        public async Task<ApiResponse<Reminders>> UpdateAsync(RemindersRequest request)
        {
            return await UpdateAsync<RemindersRequest, Reminders>("reminders/{id}.json", request);
        }

        /// <summary>
        /// Delete a single Reminders
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync("reminders/{id}.json", id);
        }
    }
}