using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the DocumentCategories endpoint of the Clio API
    /// </summary>
    public class DocumentCategoriesClient : BaseClient
    {
        public DocumentCategoriesClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all DocumentCategories
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<DocumentCategories>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<DocumentCategories>>("document_categories.json", options);
        }

        /// <summary>
        /// Return the data for a single DocumentCategories
        /// </summary>
        public async Task<ApiResponse<DocumentCategories>> GetByIdAsync(int id)
        {
            return await GetByIdAsync<DocumentCategories>("document_categories/{id}.json", id);
        }

        /// <summary>
        /// Create a new DocumentCategories
        /// </summary>
        public async Task<ApiResponse<DocumentCategories>> CreateAsync(DocumentCategoriesRequest request)
        {
            return await CreateAsync<DocumentCategoriesRequest, DocumentCategories>("document_categories.json", request);
        }

        /// <summary>
        /// Update a single DocumentCategories
        /// </summary>
        public async Task<ApiResponse<DocumentCategories>> UpdateAsync(DocumentCategoriesRequest request)
        {
            return await UpdateAsync<DocumentCategoriesRequest, DocumentCategories>("document_categories/{id}.json", request);
        }

        /// <summary>
        /// Delete a single DocumentCategories
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync<int>("document_categories/{id}.json", id);
        }
    }
}