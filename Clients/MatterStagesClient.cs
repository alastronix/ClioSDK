using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the MatterStages endpoint of the Clio API
    /// </summary>
    public class MatterStagesClient : BaseClient
    {
        public MatterStagesClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all MatterStages
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<MatterStages>>> GetAsync(
            Dictionary<string, object> parameters = null)
        {
            return await GetAsync<PaginatedResponse<MatterStages>>("matter_stages.json", parameters);
        }

        /// <summary>
        /// Return the data for a single MatterStages
        /// </summary>
        public async Task<ApiResponse<MatterStages>> GetByIdAsync(int id)
        {
            return await GetAsync<MatterStages>("matter_stages/{id}.json", id);
        }

        /// <summary>
        /// Create a new MatterStages
        /// </summary>
        public async Task<ApiResponse<MatterStages>> CreateAsync(MatterStagesRequest request)
        {
            return await CreateAsync<MatterStagesRequest, MatterStages>("matter_stages.json", request);
        }

        /// <summary>
        /// Update a single MatterStages
        /// </summary>
        public async Task<ApiResponse<MatterStages>> UpdateAsync(int id, MatterStagesRequest request)
        {
            return await UpdateAsync<MatterStagesRequest, MatterStages>("matter_stages/{id}.json", id, request);
        }

        /// <summary>
        /// Delete a single MatterStages
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync("matter_stages/{id}.json", id);
        }
    }
}