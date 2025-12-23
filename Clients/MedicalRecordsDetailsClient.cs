using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the MedicalRecordsDetails endpoint of the Clio API
    /// </summary>
    public class MedicalRecordsDetailsClient : BaseClient
    {
        public MedicalRecordsDetailsClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all MedicalRecordsDetails
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<MedicalRecordsDetails>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<MedicalRecordsDetails>>("medical_records_details.json", options);
        }

        /// <summary>
        /// Return the data for a single MedicalRecordsDetails
        /// </summary>
        public async Task<ApiResponse<MedicalRecordsDetails>> GetByIdAsync(int id)
        {
            return await GetByIdAsync("medical_records_details/{id}.json", id);
        }

        /// <summary>
        /// Create a new MedicalRecordsDetails
        /// </summary>
        public async Task<ApiResponse<MedicalRecordsDetails>> CreateAsync(MedicalRecordsDetailsRequest request)
        {
            return await CreateAsync<MedicalRecordsDetailsRequest, MedicalRecordsDetails>("medical_records_details.json", request);
        }

        /// <summary>
        /// Update a single MedicalRecordsDetails
        /// </summary>
        public async Task<ApiResponse<MedicalRecordsDetails>> UpdateAsync(MedicalRecordsDetailsRequest request)
        {
            return await UpdateAsync<MedicalRecordsDetailsRequest, MedicalRecordsDetails>("medical_records_details/{id}.json", request);
        }

        /// <summary>
        /// Delete a single MedicalRecordsDetails
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync("medical_records_details/{id}.json", id);
        }
    }
}