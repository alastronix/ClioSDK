using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the CreditMemos endpoint of the Clio API
    /// </summary>
    public class CreditMemosClient : BaseClient
    {
        public CreditMemosClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all CreditMemos
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<CreditMemos>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<CreditMemos>>("credit_memos.json", options);
        }

        /// <summary>
        /// Create a new CreditMemos
        /// </summary>
        public async Task<ApiResponse<CreditMemos>> CreateAsync(CreditMemosRequest request)
        {
            return await CreateAsync<CreditMemosRequest, CreditMemos>("credit_memos.json", request);
        }

        /// <summary>
        /// Update a single CreditMemos
        /// </summary>
        public async Task<ApiResponse<CreditMemos>> UpdateAsync(CreditMemosRequest request)
        {
            return await UpdateAsync<CreditMemosRequest, CreditMemos>("credit_memos/{id}.json", request);
        }

        /// <summary>
        /// Delete a single CreditMemos
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            await base.DeleteAsync("credit_memos/{id}.json");
                return new ApiResponse<object> { Data = default! };
        }
    }
}