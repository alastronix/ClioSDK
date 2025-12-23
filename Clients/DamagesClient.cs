using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the Damages endpoint of the Clio API
    /// </summary>
    public class DamagesClient : BaseClient
    {
        public DamagesClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all Damages
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<Damages>>> GetAsync(
            Dictionary<string, object> parameters = null)
        {
            return await GetAsync<PaginatedResponse<Damages>>("damages.json", parameters);
        }

        /// <summary>
        /// Return the data for a single Damages
        /// </summary>
        public async Task<ApiResponse<Damages>> GetByIdAsync(int id)
        {
            return await GetAsync<Damages>("damages/{id}.json", id);
        }

        /// <summary>
        /// Create a new Damages
        /// </summary>
        public async Task<ApiResponse<Damages>> CreateAsync(DamagesRequest request)
        {
            return await CreateAsync<DamagesRequest, Damages>("damages.json", request);
        }

        /// <summary>
        /// Update a single Damages
        /// </summary>
        public async Task<ApiResponse<Damages>> UpdateAsync(int id, DamagesRequest request)
        {
            return await UpdateAsync<DamagesRequest, Damages>("damages/{id}.json", id, request);
        }

        /// <summary>
        /// Delete a single Damages
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync("damages/{id}.json", id);
        }
    }
}