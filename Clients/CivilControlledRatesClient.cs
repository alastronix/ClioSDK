using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the CivilControlledRates endpoint of the Clio API
    /// </summary>
    public class CivilControlledRatesClient : BaseClient
    {
        public CivilControlledRatesClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all CivilControlledRates
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<CivilControlledRates>>> GetAsync(
            Dictionary<string, object> parameters = null)
        {
            return await GetAsync<PaginatedResponse<CivilControlledRates>>("civil_controlled_rates.json", parameters);
        }

        /// <summary>
        /// Return the data for a single CivilControlledRates
        /// </summary>
        public async Task<ApiResponse<CivilControlledRates>> GetByIdAsync(int id)
        {
            return await GetAsync<CivilControlledRates>("civil_controlled_rates/{id}.json", id);
        }

        /// <summary>
        /// Create a new CivilControlledRates
        /// </summary>
        public async Task<ApiResponse<CivilControlledRates>> CreateAsync(CivilControlledRatesRequest request)
        {
            return await CreateAsync<CivilControlledRatesRequest, CivilControlledRates>("civil_controlled_rates.json", request);
        }

        /// <summary>
        /// Update a single CivilControlledRates
        /// </summary>
        public async Task<ApiResponse<CivilControlledRates>> UpdateAsync(int id, CivilControlledRatesRequest request)
        {
            return await UpdateAsync<CivilControlledRatesRequest, CivilControlledRates>("civil_controlled_rates/{id}.json", id, request);
        }

        /// <summary>
        /// Delete a single CivilControlledRates
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync("civil_controlled_rates/{id}.json", id);
        }
    }
}