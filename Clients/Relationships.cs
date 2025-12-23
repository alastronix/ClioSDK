using ClioSDK.Core;
using ClioSDK.Models;

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

    public async System.Threading.Tasks.Task<ApiResponse<Relationship>> CreateAsync(RelationshipRequest request)
    {
        return await CreateAsync<Relationship>("", request);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Relationship>> UpdateAsync(int id, RelationshipRequest request)
    {
        return await UpdateAsync<Relationship>(id.ToString(), request);
    }

    public async System.Threading.Tasks.Task DeleteAsync(int id)
    {
        await DeleteAsync(id.ToString());
    }
}