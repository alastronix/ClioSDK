using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the TaskTypes endpoint of the Clio API
    /// </summary>
    public class TaskTypesClient : BaseClient
    {
        public TaskTypesClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all TaskTypes
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<TaskTypes>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<TaskTypes>>("task_types.json", options);
        }

        /// <summary>
        /// Return the data for a single TaskTypes
        /// </summary>
        public async Task<ApiResponse<TaskTypes>> GetByIdAsync(int id)
        {
            return await GetByIdAsync("task_types/{id}.json", id);
        }

        /// <summary>
        /// Create a new TaskTypes
        /// </summary>
        public async Task<ApiResponse<TaskTypes>> CreateAsync(TaskTypesRequest request)
        {
            return await CreateAsync<TaskTypesRequest, TaskTypes>("task_types.json", request);
        }

        /// <summary>
        /// Update a single TaskTypes
        /// </summary>
        public async Task<ApiResponse<TaskTypes>> UpdateAsync(TaskTypesRequest request)
        {
            return await UpdateAsync<TaskTypesRequest, TaskTypes>("task_types/{id}.json", request);
        }

        /// <summary>
        /// Delete a single TaskTypes
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync("task_types/{id}.json", id);
        }
    }
}