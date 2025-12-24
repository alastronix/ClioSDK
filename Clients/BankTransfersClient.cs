using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the BankTransfers endpoint of the Clio API
    /// </summary>
    public class BankTransfersClient : BaseClient
    {
        public BankTransfersClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all BankTransfers
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<BankTransfers>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<BankTransfers>>("bank_transfers.json", options);
        }

        /// <summary>
        /// Create a new BankTransfers
        /// </summary>
        public async Task<ApiResponse<BankTransfers>> CreateAsync(BankTransfersRequest request)
        {
            return await CreateAsync<BankTransfersRequest, BankTransfers>("bank_transfers.json", request);
        }

        /// <summary>
        /// Update a single BankTransfers
        /// </summary>
        public async Task<ApiResponse<BankTransfers>> UpdateAsync(BankTransfersRequest request)
        {
            return await UpdateAsync<BankTransfersRequest, BankTransfers>("bank_transfers/{id}.json", request);
        }

        /// <summary>
        /// Delete a single BankTransfers
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            await base.DeleteAsync("bank_transfers/{id}.json");
                return new ApiResponse<object> { Data = default! };
        }
    }
}