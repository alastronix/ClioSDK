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
        public async Task<ApiResponse<PaginatedResponse<MedicalBills>>> GetAsync(
            Dictionary<string, object> parameters = null)
        {
            return await GetAsync<PaginatedResponse<MedicalBills>>("medical_bills.json", parameters);
        }

        /// <summary>
        /// Return the data for a single MedicalBills
        /// </summary>
        public async Task<ApiResponse<MedicalBills>> GetByIdAsync(int id)
        {
            return await GetAsync<MedicalBills>("medical_bills/{id}.json", id);
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
        public async Task<ApiResponse<MedicalBills>> UpdateAsync(int id, MedicalBillsRequest request)
        {
            return await UpdateAsync<MedicalBillsRequest, MedicalBills>("medical_bills/{id}.json", id, request);
        }

        /// <summary>
        /// Delete a single MedicalBills
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync("medical_bills/{id}.json", id);
        }
    }
}