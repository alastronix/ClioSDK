using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the DocumentTemplates endpoint of the Clio API
    /// </summary>
    public class DocumentTemplatesClient : BaseClient
    {
        public DocumentTemplatesClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all DocumentTemplates
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<DocumentTemplates>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<DocumentTemplates>>("document_templates.json", options);
        }

        /// <summary>
        /// Create a new DocumentTemplates
        /// </summary>
        public async Task<ApiResponse<DocumentTemplates>> CreateAsync(DocumentTemplatesRequest request)
        {
            return await CreateAsync<DocumentTemplatesRequest, DocumentTemplates>("document_templates.json", request);
        }

        /// <summary>
        /// Update a single DocumentTemplates
        /// </summary>
        public async Task<ApiResponse<DocumentTemplates>> UpdateAsync(DocumentTemplatesRequest request)
        {
            return await UpdateAsync<DocumentTemplatesRequest, DocumentTemplates>("document_templates/{id}.json", request);
        }

        /// <summary>
        /// Delete a single DocumentTemplates
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            await base.DeleteAsync("document_templates/{id}.json");
                return new ApiResponse<object> { Data = default! };
        }
    }
}