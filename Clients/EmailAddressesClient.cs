using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the EmailAddresses endpoint of the Clio API
    /// </summary>
    public class EmailAddressesClient : BaseClient
    {
        public EmailAddressesClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all EmailAddresses
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<EmailAddresses>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<EmailAddresses>>("email_addresses.json", options);
        }

        /// <summary>
        /// Create a new EmailAddresses
        /// </summary>
        public async Task<ApiResponse<EmailAddresses>> CreateAsync(EmailAddressesRequest request)
        {
            return await CreateAsync<EmailAddressesRequest, EmailAddresses>("email_addresses.json", request);
        }

        /// <summary>
        /// Update a single EmailAddresses
        /// </summary>
        public async Task<ApiResponse<EmailAddresses>> UpdateAsync(EmailAddressesRequest request)
        {
            return await UpdateAsync<EmailAddressesRequest, EmailAddresses>("email_addresses/{id}.json", request);
        }

        /// <summary>
        /// Delete a single EmailAddresses
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            await base.DeleteAsync("email_addresses/{id}.json");
                return new ApiResponse<object> { Data = default! };
        }
    }
}