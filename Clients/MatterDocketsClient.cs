using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the MatterDockets endpoint of the Clio API
    /// </summary>
    public class MatterDocketsClient : BaseClient
    {
        public MatterDocketsClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all MatterDockets
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<MatterDockets>>> GetAsync(
            Dictionary<string, object> parameters = null)
        {
            return await GetAsync<PaginatedResponse<MatterDockets>>("matter_dockets.json", parameters);
        }

        /// <summary>
        /// Return the data for a single MatterDockets
        /// </summary>
        public async Task<ApiResponse<MatterDockets>> GetByIdAsync(int id)
        {
            return await GetAsync<MatterDockets>("matter_dockets/{id}.json", id);
        }

        /// <summary>
        /// Create a new MatterDockets
        /// </summary>
        public async Task<ApiResponse<MatterDockets>> CreateAsync(MatterDocketsRequest request)
        {
            return await CreateAsync<MatterDocketsRequest, MatterDockets>("matter_dockets.json", request);
        }

        /// <summary>
        /// Update a single MatterDockets
        /// </summary>
        public async Task<ApiResponse<MatterDockets>> UpdateAsync(int id, MatterDocketsRequest request)
        {
            return await UpdateAsync<MatterDocketsRequest, MatterDockets>("matter_dockets/{id}.json", id, request);
        }

        /// <summary>
        /// Delete a single MatterDockets
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync("matter_dockets/{id}.json", id);
        }
    }
}