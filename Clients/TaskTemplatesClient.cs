using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the TaskTemplates endpoint of the Clio API
    /// </summary>
    public class TaskTemplatesClient : BaseClient
    {
        public TaskTemplatesClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all TaskTemplates
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<TaskTemplates>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<TaskTemplates>>("task_templates.json", options);
        }

        /// <summary>
        /// Return the data for a single TaskTemplates
        /// </summary>
        public async Task<ApiResponse<TaskTemplates>> GetByIdAsync(int id)
        {
            return await GetByIdAsync("task_templates/{id}.json", id);
        }

        /// <summary>
        /// Create a new TaskTemplates
        /// </summary>
        public async Task<ApiResponse<TaskTemplates>> CreateAsync(TaskTemplatesRequest request)
        {
            return await CreateAsync<TaskTemplatesRequest, TaskTemplates>("task_templates.json", request);
        }

        /// <summary>
        /// Update a single TaskTemplates
        /// </summary>
        public async Task<ApiResponse<TaskTemplates>> UpdateAsync(TaskTemplatesRequest request)
        {
            return await UpdateAsync<TaskTemplatesRequest, TaskTemplates>("task_templates/{id}.json", request);
        }

        /// <summary>
        /// Delete a single TaskTemplates
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync("task_templates/{id}.json", id);
        }
    }
}