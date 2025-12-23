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
        public async Task<ApiResponse<PaginatedResponse<EmailAddresses>>> GetAsync(
            Dictionary<string, object> parameters = null)
        {
            return await GetAsync<PaginatedResponse<EmailAddresses>>("email_addresses.json", parameters);
        }

        /// <summary>
        /// Return the data for a single EmailAddresses
        /// </summary>
        public async Task<ApiResponse<EmailAddresses>> GetByIdAsync(int id)
        {
            return await GetAsync<EmailAddresses>("email_addresses/{id}.json", id);
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
        public async Task<ApiResponse<EmailAddresses>> UpdateAsync(int id, EmailAddressesRequest request)
        {
            return await UpdateAsync<EmailAddressesRequest, EmailAddresses>("email_addresses/{id}.json", id, request);
        }

        /// <summary>
        /// Delete a single EmailAddresses
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync("email_addresses/{id}.json", id);
        }
    }
}