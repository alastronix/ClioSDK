using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the ReportSchedules endpoint of the Clio API
    /// </summary>
    public class ReportSchedulesClient : BaseClient
    {
        public ReportSchedulesClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all ReportSchedules
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<ReportSchedules>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<ReportSchedules>>("report_schedules.json", options);
        }

        /// <summary>
        /// Return the data for a single ReportSchedules
        /// </summary>
        public async Task<ApiResponse<ReportSchedules>> GetByIdAsync(int id)
        {
            return await GetByIdAsync("report_schedules/{id}.json", id);
        }

        /// <summary>
        /// Create a new ReportSchedules
        /// </summary>
        public async Task<ApiResponse<ReportSchedules>> CreateAsync(ReportSchedulesRequest request)
        {
            return await CreateAsync<ReportSchedulesRequest, ReportSchedules>("report_schedules.json", request);
        }

        /// <summary>
        /// Update a single ReportSchedules
        /// </summary>
        public async Task<ApiResponse<ReportSchedules>> UpdateAsync(ReportSchedulesRequest request)
        {
            return await UpdateAsync<ReportSchedulesRequest, ReportSchedules>("report_schedules/{id}.json", request);
        }

        /// <summary>
        /// Delete a single ReportSchedules
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync("report_schedules/{id}.json", id);
        }
    }
}