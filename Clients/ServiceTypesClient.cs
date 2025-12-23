using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the ServiceTypes endpoint of the Clio API
    /// </summary>
    public class ServiceTypesClient : BaseClient
    {
        public ServiceTypesClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all ServiceTypes
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<ServiceTypes>>> GetAsync(
            Dictionary<string, object> parameters = null)
        {
            return await GetAsync<PaginatedResponse<ServiceTypes>>("service_types.json", parameters);
        }

        /// <summary>
        /// Return the data for a single ServiceTypes
        /// </summary>
        public async Task<ApiResponse<ServiceTypes>> GetByIdAsync(int id)
        {
            return await GetAsync<ServiceTypes>("service_types/{id}.json", id);
        }

        /// <summary>
        /// Create a new ServiceTypes
        /// </summary>
        public async Task<ApiResponse<ServiceTypes>> CreateAsync(ServiceTypesRequest request)
        {
            return await CreateAsync<ServiceTypesRequest, ServiceTypes>("service_types.json", request);
        }

        /// <summary>
        /// Update a single ServiceTypes
        /// </summary>
        public async Task<ApiResponse<ServiceTypes>> UpdateAsync(int id, ServiceTypesRequest request)
        {
            return await UpdateAsync<ServiceTypesRequest, ServiceTypes>("service_types/{id}.json", id, request);
        }

        /// <summary>
        /// Delete a single ServiceTypes
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync("service_types/{id}.json", id);
        }
    }
}