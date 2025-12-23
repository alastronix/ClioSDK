using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the PhoneNumbers endpoint of the Clio API
    /// </summary>
    public class PhoneNumbersClient : BaseClient
    {
        public PhoneNumbersClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all PhoneNumbers
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<PhoneNumbers>>> GetAsync(
            Dictionary<string, object> parameters = null)
        {
            return await GetAsync<PaginatedResponse<PhoneNumbers>>("phone_numbers.json", parameters);
        }

        /// <summary>
        /// Return the data for a single PhoneNumbers
        /// </summary>
        public async Task<ApiResponse<PhoneNumbers>> GetByIdAsync(int id)
        {
            return await GetAsync<PhoneNumbers>("phone_numbers/{id}.json", id);
        }

        /// <summary>
        /// Create a new PhoneNumbers
        /// </summary>
        public async Task<ApiResponse<PhoneNumbers>> CreateAsync(PhoneNumbersRequest request)
        {
            return await CreateAsync<PhoneNumbersRequest, PhoneNumbers>("phone_numbers.json", request);
        }

        /// <summary>
        /// Update a single PhoneNumbers
        /// </summary>
        public async Task<ApiResponse<PhoneNumbers>> UpdateAsync(int id, PhoneNumbersRequest request)
        {
            return await UpdateAsync<PhoneNumbersRequest, PhoneNumbers>("phone_numbers/{id}.json", id, request);
        }

        /// <summary>
        /// Delete a single PhoneNumbers
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync("phone_numbers/{id}.json", id);
        }
    }
}