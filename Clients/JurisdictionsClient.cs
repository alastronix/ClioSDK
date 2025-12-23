using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the Jurisdictions endpoint of the Clio API
    /// </summary>
    public class JurisdictionsClient : BaseClient
    {
        public JurisdictionsClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all Jurisdictions
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<Jurisdictions>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<Jurisdictions>>("jurisdictions.json", options);
        }

        /// <summary>
        /// Return the data for a single Jurisdictions
        /// </summary>
        public async Task<ApiResponse<Jurisdictions>> GetByIdAsync(int id)
        {
            return await GetByIdAsync<Jurisdictions>("jurisdictions/{id}.json", id);
        }

        /// <summary>
        /// Create a new Jurisdictions
        /// </summary>
        public async Task<ApiResponse<Jurisdictions>> CreateAsync(JurisdictionsRequest request)
        {
            return await CreateAsync<JurisdictionsRequest, Jurisdictions>("jurisdictions.json", request);
        }

        /// <summary>
        /// Update a single Jurisdictions
        /// </summary>
        public async Task<ApiResponse<Jurisdictions>> UpdateAsync(JurisdictionsRequest request)
        {
            return await UpdateAsync<JurisdictionsRequest, Jurisdictions>("jurisdictions/{id}.json", request);
        }

        /// <summary>
        /// Delete a single Jurisdictions
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync<int>("jurisdictions/{id}.json", id);
        }
    }
}