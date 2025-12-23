using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the TaskTemplateLists endpoint of the Clio API
    /// </summary>
    public class TaskTemplateListsClient : BaseClient
    {
        public TaskTemplateListsClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all TaskTemplateLists
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<TaskTemplateLists>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<TaskTemplateLists>>("task_template_lists.json", options);
        }

        /// <summary>
        /// Return the data for a single TaskTemplateLists
        /// </summary>
        public async Task<ApiResponse<TaskTemplateLists>> GetByIdAsync(int id)
        {
            return await GetByIdAsync("task_template_lists/{id}.json", id);
        }

        /// <summary>
        /// Create a new TaskTemplateLists
        /// </summary>
        public async Task<ApiResponse<TaskTemplateLists>> CreateAsync(TaskTemplateListsRequest request)
        {
            return await CreateAsync<TaskTemplateListsRequest, TaskTemplateLists>("task_template_lists.json", request);
        }

        /// <summary>
        /// Update a single TaskTemplateLists
        /// </summary>
        public async Task<ApiResponse<TaskTemplateLists>> UpdateAsync(TaskTemplateListsRequest request)
        {
            return await UpdateAsync<TaskTemplateListsRequest, TaskTemplateLists>("task_template_lists/{id}.json", request);
        }

        /// <summary>
        /// Delete a single TaskTemplateLists
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync("task_template_lists/{id}.json", id);
        }
    }
}