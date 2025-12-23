using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the CriminalControlledRates endpoint of the Clio API
    /// </summary>
    public class CriminalControlledRatesClient : BaseClient
    {
        public CriminalControlledRatesClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all CriminalControlledRates
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<CriminalControlledRates>>> GetAsync(
            Dictionary<string, object> parameters = null)
        {
            return await GetAsync<PaginatedResponse<CriminalControlledRates>>("criminal_controlled_rates.json", parameters);
        }

        /// <summary>
        /// Return the data for a single CriminalControlledRates
        /// </summary>
        public async Task<ApiResponse<CriminalControlledRates>> GetByIdAsync(int id)
        {
            return await GetAsync<CriminalControlledRates>("criminal_controlled_rates/{id}.json", id);
        }

        /// <summary>
        /// Create a new CriminalControlledRates
        /// </summary>
        public async Task<ApiResponse<CriminalControlledRates>> CreateAsync(CriminalControlledRatesRequest request)
        {
            return await CreateAsync<CriminalControlledRatesRequest, CriminalControlledRates>("criminal_controlled_rates.json", request);
        }

        /// <summary>
        /// Update a single CriminalControlledRates
        /// </summary>
        public async Task<ApiResponse<CriminalControlledRates>> UpdateAsync(int id, CriminalControlledRatesRequest request)
        {
            return await UpdateAsync<CriminalControlledRatesRequest, CriminalControlledRates>("criminal_controlled_rates/{id}.json", id, request);
        }

        /// <summary>
        /// Delete a single CriminalControlledRates
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync("criminal_controlled_rates/{id}.json", id);
        }
    }
}