using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients
{
    /// <summary>
    /// Client for interacting with the JurisdictionsToTriggers endpoint of the Clio API
    /// </summary>
    public class JurisdictionsToTriggersClient : BaseClient
    {
        public JurisdictionsToTriggersClient(HttpClient httpClient, string baseEndpoint) 
            : base(httpClient, baseEndpoint)
        {
        }

        /// <summary>
        /// Return the data for all JurisdictionsToTriggers
        /// </summary>
        public async Task<ApiResponse<PaginatedResponse<JurisdictionsToTriggers>>> GetAsync(
            Dictionary<string, object> parameters = null)
        {
            return await GetAsync<PaginatedResponse<JurisdictionsToTriggers>>("jurisdictions_to_triggers.json", parameters);
        }

        /// <summary>
        /// Return the data for a single JurisdictionsToTriggers
        /// </summary>
        public async Task<ApiResponse<JurisdictionsToTriggers>> GetByIdAsync(int id)
        {
            return await GetAsync<JurisdictionsToTriggers>("jurisdictions_to_triggers/{id}.json", id);
        }

        /// <summary>
        /// Create a new JurisdictionsToTriggers
        /// </summary>
        public async Task<ApiResponse<JurisdictionsToTriggers>> CreateAsync(JurisdictionsToTriggersRequest request)
        {
            return await CreateAsync<JurisdictionsToTriggersRequest, JurisdictionsToTriggers>("jurisdictions_to_triggers.json", request);
        }

        /// <summary>
        /// Update a single JurisdictionsToTriggers
        /// </summary>
        public async Task<ApiResponse<JurisdictionsToTriggers>> UpdateAsync(int id, JurisdictionsToTriggersRequest request)
        {
            return await UpdateAsync<JurisdictionsToTriggersRequest, JurisdictionsToTriggers>("jurisdictions_to_triggers/{id}.json", id, request);
        }

        /// <summary>
        /// Delete a single JurisdictionsToTriggers
        /// </summary>
        public async Task<ApiResponse<object>> DeleteAsync(int id)
        {
            return await DeleteAsync("jurisdictions_to_triggers/{id}.json", id);
        }
    }
}