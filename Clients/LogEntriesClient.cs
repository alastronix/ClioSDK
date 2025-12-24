using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the LogEntries endpoint of the Clio API
    /// </summary>
    public class LogEntriesClient : BaseClient
    {
        public LogEntriesClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all LogEntries
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<LogEntries>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<LogEntries>>("log_entries.json", options);
        }

        /// <summary>
        /// Create a new LogEntries
        /// </summary>
        public async Task<ApiResponse<LogEntries>> CreateAsync(LogEntriesRequest request)
        {
            return await CreateAsync<LogEntriesRequest, LogEntries>("log_entries.json", request);
        }

        /// <summary>
        /// Update a single LogEntries
        /// </summary>
        public async Task<ApiResponse<LogEntries>> UpdateAsync(LogEntriesRequest request)
        {
            return await UpdateAsync<LogEntriesRequest, LogEntries>("log_entries/{id}.json", request);
        }

        /// <summary>
        /// Delete a single LogEntries
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            await base.DeleteAsync("log_entries/{id}.json");
                return new ApiResponse<object> { Data = default! };
        }
    }
}