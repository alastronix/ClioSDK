using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the DocumentArchives endpoint of the Clio API
    /// </summary>
    public class DocumentArchivesClient : BaseClient
    {
        public DocumentArchivesClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all DocumentArchives
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<DocumentArchives>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<DocumentArchives>>("document_archives.json", options);
        }

        /// <summary>
        /// Return the data for a single DocumentArchives
        /// </summary>
        public async Task<ApiResponse<DocumentArchives>> GetByIdAsync(int id)
        {
            return await GetByIdAsync<DocumentArchives>("document_archives/{id}.json", id);
        }

        /// <summary>
        /// Create a new DocumentArchives
        /// </summary>
        public async Task<ApiResponse<DocumentArchives>> CreateAsync(DocumentArchivesRequest request)
        {
            return await CreateAsync<DocumentArchivesRequest, DocumentArchives>("document_archives.json", request);
        }

        /// <summary>
        /// Update a single DocumentArchives
        /// </summary>
        public async Task<ApiResponse<DocumentArchives>> UpdateAsync(DocumentArchivesRequest request)
        {
            return await UpdateAsync<DocumentArchivesRequest, DocumentArchives>("document_archives/{id}.json", request);
        }

        /// <summary>
        /// Delete a single DocumentArchives
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync<int>("document_archives/{id}.json", id);
        }
    }
}