using Timer = ClioSDK.Models.Timer;
using Task = System.Threading.Tasks.Task;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients;

public class TimersClient : BaseClient
{
    private readonly HttpClient _httpClient;

    public TimersClient(HttpClient httpClient) : base(httpClient, "timers")
    {
        _httpClient = httpClient;
    }

    public async System.Threading.Tasks.Task<PaginatedResponse<Timer>> GetAsync(QueryOptions? options = null)
    {
        return await GetListAsync<Timer>("", options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Timer>> GetAsync(int id, QueryOptions? options = null)
    {
        return await GetAsync<Timer>(id.ToString(), options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Timer>> CreateAsync(TimerRequest request)
    {
        return await CreateAsync<Timer>("", request);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Timer>> UpdateAsync(int id, TimerRequest request)
    {
        return await UpdateAsync<Timer>(id.ToString(), request);
    }

    public async System.Threading.Tasks.Task DeleteAsync(int id)
    {
        await DeleteAsync(id.ToString());
    }
}