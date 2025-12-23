using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the Reports endpoint of the Clio API
    /// </summary>
    public class ReportsClient : BaseClient
    {
        public ReportsClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all Reports
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<Reports>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<Reports>>("reports.json", options);
        }

        /// <summary>
        /// Return the data for a single Reports
        /// </summary>
        public async Task<ApiResponse<Reports>> GetByIdAsync(int id)
        {
            return await GetByIdAsync("reports/{id}.json", id);
        }

        /// <summary>
        /// Create a new Reports
        /// </summary>
        public async Task<ApiResponse<Reports>> CreateAsync(ReportsRequest request)
        {
            return await CreateAsync<ReportsRequest, Reports>("reports.json", request);
        }

        /// <summary>
        /// Update a single Reports
        /// </summary>
        public async Task<ApiResponse<Reports>> UpdateAsync(ReportsRequest request)
        {
            return await UpdateAsync<ReportsRequest, Reports>("reports/{id}.json", request);
        }

        /// <summary>
        /// Delete a single Reports
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync("reports/{id}.json", id);
        }
    }
}