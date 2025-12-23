using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the DocumentAutomations endpoint of the Clio API
    /// </summary>
    public class DocumentAutomationsClient : BaseClient
    {
        public DocumentAutomationsClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all DocumentAutomations
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<DocumentAutomations>>> GetAsync(
            Dictionary<string, object> parameters = null)
        {
            return await GetAsync<PaginatedResponse<DocumentAutomations>>("document_automations.json", parameters);
        }

        /// <summary>
        /// Return the data for a single DocumentAutomations
        /// </summary>
        public async Task<ApiResponse<DocumentAutomations>> GetByIdAsync(int id)
        {
            return await GetAsync<DocumentAutomations>("document_automations/{id}.json", id);
        }

        /// <summary>
        /// Create a new DocumentAutomations
        /// </summary>
        public async Task<ApiResponse<DocumentAutomations>> CreateAsync(DocumentAutomationsRequest request)
        {
            return await CreateAsync<DocumentAutomationsRequest, DocumentAutomations>("document_automations.json", request);
        }

        /// <summary>
        /// Update a single DocumentAutomations
        /// </summary>
        public async Task<ApiResponse<DocumentAutomations>> UpdateAsync(int id, DocumentAutomationsRequest request)
        {
            return await UpdateAsync<DocumentAutomationsRequest, DocumentAutomations>("document_automations/{id}.json", id, request);
        }

        /// <summary>
        /// Delete a single DocumentAutomations
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync("document_automations/{id}.json", id);
        }
    }
}