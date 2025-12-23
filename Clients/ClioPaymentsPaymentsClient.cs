using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the ClioPaymentsPayments endpoint of the Clio API
    /// </summary>
    public class ClioPaymentsPaymentsClient : BaseClient
    {
        public ClioPaymentsPaymentsClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all ClioPaymentsPayments
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<ClioPaymentsPayments>>> GetAsync(
            Dictionary<string, object> parameters = null)
        {
            return await GetAsync<PaginatedResponse<ClioPaymentsPayments>>("clio_paymentspayments.json", parameters);
        }

        /// <summary>
        /// Return the data for a single ClioPaymentsPayments
        /// </summary>
        public async Task<ApiResponse<ClioPaymentsPayments>> GetByIdAsync(int id)
        {
            return await GetAsync<ClioPaymentsPayments>("clio_paymentspayments/{id}.json", id);
        }

        /// <summary>
        /// Create a new ClioPaymentsPayments
        /// </summary>
        public async Task<ApiResponse<ClioPaymentsPayments>> CreateAsync(ClioPaymentsPaymentsRequest request)
        {
            return await CreateAsync<ClioPaymentsPaymentsRequest, ClioPaymentsPayments>("clio_paymentspayments.json", request);
        }

        /// <summary>
        /// Update a single ClioPaymentsPayments
        /// </summary>
        public async Task<ApiResponse<ClioPaymentsPayments>> UpdateAsync(int id, ClioPaymentsPaymentsRequest request)
        {
            return await UpdateAsync<ClioPaymentsPaymentsRequest, ClioPaymentsPayments>("clio_paymentspayments/{id}.json", id, request);
        }

        /// <summary>
        /// Delete a single ClioPaymentsPayments
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync("clio_paymentspayments/{id}.json", id);
        }
    }
}