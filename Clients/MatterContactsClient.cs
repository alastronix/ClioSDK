using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the MatterContacts endpoint of the Clio API
    /// </summary>
    public class MatterContactsClient : BaseClient
    {
        public MatterContactsClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all MatterContacts
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<MatterContacts>>> GetAsync(
            Dictionary<string, object> parameters = null)
        {
            return await GetAsync<PaginatedResponse<MatterContacts>>("matter_contacts.json", parameters);
        }

        /// <summary>
        /// Return the data for a single MatterContacts
        /// </summary>
        public async Task<ApiResponse<MatterContacts>> GetByIdAsync(int id)
        {
            return await GetAsync<MatterContacts>("matter_contacts/{id}.json", id);
        }

        /// <summary>
        /// Create a new MatterContacts
        /// </summary>
        public async Task<ApiResponse<MatterContacts>> CreateAsync(MatterContactsRequest request)
        {
            return await CreateAsync<MatterContactsRequest, MatterContacts>("matter_contacts.json", request);
        }

        /// <summary>
        /// Update a single MatterContacts
        /// </summary>
        public async Task<ApiResponse<MatterContacts>> UpdateAsync(int id, MatterContactsRequest request)
        {
            return await UpdateAsync<MatterContactsRequest, MatterContacts>("matter_contacts/{id}.json", id, request);
        }

        /// <summary>
        /// Delete a single MatterContacts
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync("matter_contacts/{id}.json", id);
        }
    }
}