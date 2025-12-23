using Task = System.Threading.Tasks.Task;
using ClioSDK.Core;
using ClioSDK.Models;
using ClioSDK.Models.Requests;

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

    public async System.Threading.Tasks.Task<ApiResponse<Activity>> CreateAsync(ClioSDK.Models.Requests.ActivityRequest request)
    {
        return await CreateAsync<ClioSDK.Models.Requests.ActivityRequest, Activity>("", request);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Activity>> UpdateAsync(int id, ClioSDK.Models.Requests.ActivityRequest request)
    {
        return await UpdateAsync<ClioSDK.Models.Requests.ActivityRequest, Activity>(id.ToString(), request);
    }

    public async System.Threading.Tasks.Task DeleteAsync(int id)
    {
        await DeleteAsync(id.ToString());
    }
}