using Task = System.Threading.Tasks.Task;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients;

public class GroupsClient : BaseClient
{
    private readonly HttpClient _httpClient;

    public GroupsClient(HttpClient httpClient) : base(httpClient, "groups")
    {
        _httpClient = httpClient;
    }

    public async System.Threading.Tasks.Task<PaginatedResponse<Group>> GetAsync(QueryOptions? options = null)
    {
        return await GetListAsync<Group>("", options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Group>> GetAsync(int id, QueryOptions? options = null)
    {
        return await GetAsync<Group>(id.ToString(), options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Group>> CreateAsync(GroupRequest request)
    {
        return await CreateAsync<Group>("", request);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Group>> UpdateAsync(int id, GroupRequest request)
    {
        return await UpdateAsync<Group>(id.ToString(), request);
    }

    public async System.Threading.Tasks.Task DeleteAsync(int id)
    {
        await DeleteAsync(id.ToString());
    }
}