using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the InterestCharges endpoint of the Clio API
    /// </summary>
    public class InterestChargesClient : BaseClient
    {
        public InterestChargesClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all InterestCharges
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<InterestCharges>>> GetAsync(QueryOptions? options = null)
        {
            return await GetAsync<PaginatedResponse<InterestCharges>>("interest_charges.json", options);
        }

        /// <summary>
        /// Create a new InterestCharges
        /// </summary>
        public async Task<ApiResponse<InterestCharges>> CreateAsync(InterestChargesRequest request)
        {
            return await CreateAsync<InterestChargesRequest, InterestCharges>("interest_charges.json", request);
        }

        /// <summary>
        /// Update a single InterestCharges
        /// </summary>
        public async Task<ApiResponse<InterestCharges>> UpdateAsync(InterestChargesRequest request)
        {
            return await UpdateAsync<InterestChargesRequest, InterestCharges>("interest_charges/{id}.json", request);
        }

        /// <summary>
        /// Delete a single InterestCharges
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            await base.DeleteAsync("interest_charges/{id}.json");
                return new ApiResponse<object> { Data = default! };
        }
    }
}