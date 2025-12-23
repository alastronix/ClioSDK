using Task = System.Threading.Tasks.Task;
using ClioSDK.Core;
using ClioSDK.Models;
using ClioSDK.Models.Requests;

namespace ClioSDK.Clients;

public class RelationshipsClient : BaseClient
{
    private readonly HttpClient _httpClient;

    public RelationshipsClient(HttpClient httpClient) : base(httpClient, "relationships")
    {
        _httpClient = httpClient;
    }

    public async System.Threading.Tasks.Task<PaginatedResponse<Relationship>> GetAsync(QueryOptions? options = null)
    {
        return await GetListAsync<Relationship>("", options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Relationship>> GetAsync(int id, QueryOptions? options = null)
    {
        return await GetAsync<Relationship>(id.ToString(), options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Relationship>> CreateAsync(ClioSDK.Models.Requests.RelationshipRequest request)
    {
        return await CreateAsync<ClioSDK.Models.Requests.RelationshipRequest, Relationship>("", request);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Relationship>> UpdateAsync(int id, ClioSDK.Models.Requests.RelationshipRequest request)
    {
        return await UpdateAsync<ClioSDK.Models.Requests.RelationshipRequest, Relationship>(id.ToString(), request);
    }

    public async System.Threading.Tasks.Task DeleteAsync(int id)
    {
        await DeleteAsync(id.ToString());
    }
}