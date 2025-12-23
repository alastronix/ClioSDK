using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the Currencies endpoint of the Clio API
    /// </summary>
    public class CurrenciesClient : BaseClient
    {
        public CurrenciesClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all Currencies
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<Currencies>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<Currencies>>("currencies.json", options);
        }

        /// <summary>
        /// Return the data for a single Currencies
        /// </summary>
        public async Task<ApiResponse<Currencies>> GetByIdAsync(int id)
        {
            return await GetByIdAsync("currencies/{id}.json", id);
        }

        /// <summary>
        /// Create a new Currencies
        /// </summary>
        public async Task<ApiResponse<Currencies>> CreateAsync(CurrenciesRequest request)
        {
            return await CreateAsync<CurrenciesRequest, Currencies>("currencies.json", request);
        }

        /// <summary>
        /// Update a single Currencies
        /// </summary>
        public async Task<ApiResponse<Currencies>> UpdateAsync(CurrenciesRequest request)
        {
            return await UpdateAsync<CurrenciesRequest, Currencies>("currencies/{id}.json", request);
        }

        /// <summary>
        /// Delete a single Currencies
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync("currencies/{id}.json", id);
        }
    }
}