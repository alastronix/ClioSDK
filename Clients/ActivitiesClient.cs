using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients;

public class ActivitiesClient : BaseClient
{
    private readonly HttpClient _httpClient;

    public ActivitiesClient(HttpClient httpClient) : base(httpClient, "activities")
    {
        _httpClient = httpClient;
    }

    public async System.Threading.Tasks.Task<PaginatedResponse<Activity>> GetAsync(QueryOptions? options = null)
    {
        return await GetListAsync<Activity>("", options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Activity>> GetAsync(int id, QueryOptions? options = null)
    {
        return await GetAsync<Activity>(id.ToString(), options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Activity>> CreateAsync(ActivityRequest request)
    {
        return await CreateAsync<Activity>("", request);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Activity>> UpdateAsync(int id, ActivityRequest request)
    {
        return await UpdateAsync<Activity>(id.ToString(), request);
    }

    public async System.Threading.Tasks.Task DeleteAsync(int id)
    {
        await DeleteAsync(id.ToString());
    }
}