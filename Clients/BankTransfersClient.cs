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
        public async Task<ApiResponse<PaginatedResponse<BankTransfers>>> GetAsync(
            Dictionary<string, object> parameters = null)
        {
            return await GetAsync<PaginatedResponse<BankTransfers>>("bank_transfers.json", parameters);
        }

        /// <summary>
        /// Return the data for a single BankTransfers
        /// </summary>
        public async Task<ApiResponse<BankTransfers>> GetByIdAsync(int id)
        {
            return await GetAsync<BankTransfers>("bank_transfers/{id}.json", id);
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
        public async Task<ApiResponse<BankTransfers>> UpdateAsync(int id, BankTransfersRequest request)
        {
            return await UpdateAsync<BankTransfersRequest, BankTransfers>("bank_transfers/{id}.json", id, request);
        }

        /// <summary>
        /// Delete a single BankTransfers
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync("bank_transfers/{id}.json", id);
        }
    }
}