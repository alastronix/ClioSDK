using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the UtbmsCodes endpoint of the Clio API
    /// </summary>
    public class UtbmsCodesClient : BaseClient
    {
        public UtbmsCodesClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all UtbmsCodes
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<UtbmsCodes>>> GetAsync(
            Dictionary<string, object> parameters = null)
        {
            return await GetAsync<PaginatedResponse<UtbmsCodes>>("utbmscodes.json", parameters);
        }

        /// <summary>
        /// Return the data for a single UtbmsCodes
        /// </summary>
        public async Task<ApiResponse<UtbmsCodes>> GetByIdAsync(int id)
        {
            return await GetAsync<UtbmsCodes>("utbmscodes/{id}.json", id);
        }

        /// <summary>
        /// Create a new UtbmsCodes
        /// </summary>
        public async Task<ApiResponse<UtbmsCodes>> CreateAsync(UtbmsCodesRequest request)
        {
            return await CreateAsync<UtbmsCodesRequest, UtbmsCodes>("utbmscodes.json", request);
        }

        /// <summary>
        /// Update a single UtbmsCodes
        /// </summary>
        public async Task<ApiResponse<UtbmsCodes>> UpdateAsync(int id, UtbmsCodesRequest request)
        {
            return await UpdateAsync<UtbmsCodesRequest, UtbmsCodes>("utbmscodes/{id}.json", id, request);
        }

        /// <summary>
        /// Delete a single UtbmsCodes
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync("utbmscodes/{id}.json", id);
        }
    }
}