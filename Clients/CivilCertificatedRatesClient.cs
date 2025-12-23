using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the CivilCertificatedRates endpoint of the Clio API
    /// </summary>
    public class CivilCertificatedRatesClient : BaseClient
    {
        public CivilCertificatedRatesClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all CivilCertificatedRates
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<CivilCertificatedRates>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<CivilCertificatedRates>>("civil_certificated_rates.json", options);
        }

        /// <summary>
        /// Return the data for a single CivilCertificatedRates
        /// </summary>
        public async Task<ApiResponse<CivilCertificatedRates>> GetByIdAsync(int id)
        {
            return await GetByIdAsync("civil_certificated_rates/{id}.json", id);
        }

        /// <summary>
        /// Create a new CivilCertificatedRates
        /// </summary>
        public async Task<ApiResponse<CivilCertificatedRates>> CreateAsync(CivilCertificatedRatesRequest request)
        {
            return await CreateAsync<CivilCertificatedRatesRequest, CivilCertificatedRates>("civil_certificated_rates.json", request);
        }

        /// <summary>
        /// Update a single CivilCertificatedRates
        /// </summary>
        public async Task<ApiResponse<CivilCertificatedRates>> UpdateAsync(CivilCertificatedRatesRequest request)
        {
            return await UpdateAsync<CivilCertificatedRatesRequest, CivilCertificatedRates>("civil_certificated_rates/{id}.json", request);
        }

        /// <summary>
        /// Delete a single CivilCertificatedRates
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync("civil_certificated_rates/{id}.json", id);
        }
    }
}