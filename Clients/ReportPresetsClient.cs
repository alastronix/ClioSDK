using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the ReportPresets endpoint of the Clio API
    /// </summary>
    public class ReportPresetsClient : BaseClient
    {
        public ReportPresetsClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all ReportPresets
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<ReportPresets>>> GetAsync(
            Dictionary<string, object> parameters = null)
        {
            return await GetAsync<PaginatedResponse<ReportPresets>>("report_presets.json", parameters);
        }

        /// <summary>
        /// Return the data for a single ReportPresets
        /// </summary>
        public async Task<ApiResponse<ReportPresets>> GetByIdAsync(int id)
        {
            return await GetAsync<ReportPresets>("report_presets/{id}.json", id);
        }

        /// <summary>
        /// Create a new ReportPresets
        /// </summary>
        public async Task<ApiResponse<ReportPresets>> CreateAsync(ReportPresetsRequest request)
        {
            return await CreateAsync<ReportPresetsRequest, ReportPresets>("report_presets.json", request);
        }

        /// <summary>
        /// Update a single ReportPresets
        /// </summary>
        public async Task<ApiResponse<ReportPresets>> UpdateAsync(int id, ReportPresetsRequest request)
        {
            return await UpdateAsync<ReportPresetsRequest, ReportPresets>("report_presets/{id}.json", id, request);
        }

        /// <summary>
        /// Delete a single ReportPresets
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync("report_presets/{id}.json", id);
        }
    }
}