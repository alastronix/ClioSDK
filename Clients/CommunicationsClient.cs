using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the Communications endpoint of the Clio API
    /// </summary>
    public class CommunicationsClient : BaseClient
    {
        public CommunicationsClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all Communications
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<Communications>>> GetAsync(
            Dictionary<string, object> parameters = null)
        {
            return await GetAsync<PaginatedResponse<Communications>>("communications.json", parameters);
        }

        /// <summary>
        /// Return the data for a single Communications
        /// </summary>
        public async Task<ApiResponse<Communications>> GetByIdAsync(int id)
        {
            return await GetAsync<Communications>("communications/{id}.json", id);
        }

        /// <summary>
        /// Create a new Communications
        /// </summary>
        public async Task<ApiResponse<Communications>> CreateAsync(CommunicationsRequest request)
        {
            return await CreateAsync<CommunicationsRequest, Communications>("communications.json", request);
        }

        /// <summary>
        /// Update a single Communications
        /// </summary>
        public async Task<ApiResponse<Communications>> UpdateAsync(int id, CommunicationsRequest request)
        {
            return await UpdateAsync<CommunicationsRequest, Communications>("communications/{id}.json", id, request);
        }

        /// <summary>
        /// Delete a single Communications
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync("communications/{id}.json", id);
        }
    }
}