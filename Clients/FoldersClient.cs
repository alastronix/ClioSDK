using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the Folders endpoint of the Clio API
    /// </summary>
    public class FoldersClient : BaseClient
    {
        public FoldersClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all Folders
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<Folders>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<Folders>>("folders.json", options);
        }

        /// <summary>
        /// Return the data for a single Folders
        /// </summary>
        public async Task<ApiResponse<Folders>> GetByIdAsync(int id)
        {
            return await GetByIdAsync("folders/{id}.json", id);
        }

        /// <summary>
        /// Create a new Folders
        /// </summary>
        public async Task<ApiResponse<Folders>> CreateAsync(FoldersRequest request)
        {
            return await CreateAsync<FoldersRequest, Folders>("folders.json", request);
        }

        /// <summary>
        /// Update a single Folders
        /// </summary>
        public async Task<ApiResponse<Folders>> UpdateAsync(FoldersRequest request)
        {
            return await UpdateAsync<FoldersRequest, Folders>("folders/{id}.json", request);
        }

        /// <summary>
        /// Delete a single Folders
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync("folders/{id}.json", id);
        }
    }
}