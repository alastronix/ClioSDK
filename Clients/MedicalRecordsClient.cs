using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the MedicalRecords endpoint of the Clio API
    /// </summary>
    public class MedicalRecordsClient : BaseClient
    {
        public MedicalRecordsClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all MedicalRecords
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<MedicalRecords>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<MedicalRecords>>("medical_records.json", options);
        }

        /// <summary>
        /// Create a new MedicalRecords
        /// </summary>
        public async Task<ApiResponse<MedicalRecords>> CreateAsync(MedicalRecordsRequest request)
        {
            return await CreateAsync<MedicalRecordsRequest, MedicalRecords>("medical_records.json", request);
        }

        /// <summary>
        /// Update a single MedicalRecords
        /// </summary>
        public async Task<ApiResponse<MedicalRecords>> UpdateAsync(MedicalRecordsRequest request)
        {
            return await UpdateAsync<MedicalRecordsRequest, MedicalRecords>("medical_records/{id}.json", request);
        }

        /// <summary>
        /// Delete a single MedicalRecords
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            await base.DeleteAsync("medical_records/{id}.json");
                return new ApiResponse<object> { Data = default! };
        }
    }
}