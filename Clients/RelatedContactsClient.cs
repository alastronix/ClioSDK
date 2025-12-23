using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the RelatedContacts endpoint of the Clio API
    /// </summary>
    public class RelatedContactsClient : BaseClient
    {
        public RelatedContactsClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all RelatedContacts
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<RelatedContacts>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<RelatedContacts>>("related_contacts.json", options);
        }

        /// <summary>
        /// Return the data for a single RelatedContacts
        /// </summary>
        public async Task<ApiResponse<RelatedContacts>> GetByIdAsync(int id)
        {
            return await GetByIdAsync<RelatedContacts>("related_contacts/{id}.json", id);
        }

        /// <summary>
        /// Create a new RelatedContacts
        /// </summary>
        public async Task<ApiResponse<RelatedContacts>> CreateAsync(RelatedContactsRequest request)
        {
            return await CreateAsync<RelatedContactsRequest, RelatedContacts>("related_contacts.json", request);
        }

        /// <summary>
        /// Update a single RelatedContacts
        /// </summary>
        public async Task<ApiResponse<RelatedContacts>> UpdateAsync(RelatedContactsRequest request)
        {
            return await UpdateAsync<RelatedContactsRequest, RelatedContacts>("related_contacts/{id}.json", request);
        }

        /// <summary>
        /// Delete a single RelatedContacts
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync<int>("related_contacts/{id}.json", id);
        }
    }
}