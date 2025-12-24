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
        public async Task<ApiResponse<PaginatedResponse<Damages>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<Damages>>("damages.json", options);
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
        public async Task<ApiResponse<Damages>> UpdateAsync(DamagesRequest request)
        {
            return await UpdateAsync<DamagesRequest, Damages>("damages/{id}.json", request);
        }

        /// <summary>
        /// Delete a single Damages
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            await base.DeleteAsync("damages/{id}.json");
                return new ApiResponse<object> { Data = default! };
        }
    }
}