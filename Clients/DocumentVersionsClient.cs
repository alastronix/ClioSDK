using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the DocumentVersions endpoint of the Clio API
    /// </summary>
    public class DocumentVersionsClient : BaseClient
    {
        public DocumentVersionsClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all DocumentVersions
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<DocumentVersions>>> GetAsync(
            Dictionary<string, object> parameters = null)
        {
            return await GetAsync<PaginatedResponse<DocumentVersions>>("document_versions.json", parameters);
        }

        /// <summary>
        /// Return the data for a single DocumentVersions
        /// </summary>
        public async Task<ApiResponse<DocumentVersions>> GetByIdAsync(int id)
        {
            return await GetAsync<DocumentVersions>("document_versions/{id}.json", id);
        }

        /// <summary>
        /// Create a new DocumentVersions
        /// </summary>
        public async Task<ApiResponse<DocumentVersions>> CreateAsync(DocumentVersionsRequest request)
        {
            return await CreateAsync<DocumentVersionsRequest, DocumentVersions>("document_versions.json", request);
        }

        /// <summary>
        /// Update a single DocumentVersions
        /// </summary>
        public async Task<ApiResponse<DocumentVersions>> UpdateAsync(int id, DocumentVersionsRequest request)
        {
            return await UpdateAsync<DocumentVersionsRequest, DocumentVersions>("document_versions/{id}.json", id, request);
        }

        /// <summary>
        /// Delete a single DocumentVersions
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync("document_versions/{id}.json", id);
        }
    }
}