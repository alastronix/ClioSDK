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
        public async Task<ApiResponse<PaginatedResponse<PhoneNumbers>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<PhoneNumbers>>("phone_numbers.json", options);
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
        public async Task<ApiResponse<PhoneNumbers>> UpdateAsync(PhoneNumbersRequest request)
        {
            return await UpdateAsync<PhoneNumbersRequest, PhoneNumbers>("phone_numbers/{id}.json", request);
        }

        /// <summary>
        /// Delete a single PhoneNumbers
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            await base.DeleteAsync("phone_numbers/{id}.json");
                return new ApiResponse<object> { Data = default! };
        }
    }
}