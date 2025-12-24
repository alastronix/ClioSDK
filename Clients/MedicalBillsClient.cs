using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the MedicalBills endpoint of the Clio API
    /// </summary>
    public class MedicalBillsClient : BaseClient
    {
        public MedicalBillsClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all MedicalBills
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<MedicalBills>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<MedicalBills>>("medical_bills.json", options);
        }

        /// <summary>
        /// Create a new MedicalBills
        /// </summary>
        public async Task<ApiResponse<MedicalBills>> CreateAsync(MedicalBillsRequest request)
        {
            return await CreateAsync<MedicalBillsRequest, MedicalBills>("medical_bills.json", request);
        }

        /// <summary>
        /// Update a single MedicalBills
        /// </summary>
        public async Task<ApiResponse<MedicalBills>> UpdateAsync(MedicalBillsRequest request)
        {
            return await UpdateAsync<MedicalBillsRequest, MedicalBills>("medical_bills/{id}.json", request);
        }

        /// <summary>
        /// Delete a single MedicalBills
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            await base.DeleteAsync("medical_bills/{id}.json");
                return new ApiResponse<object> { Data = default! };
        }
    }
}