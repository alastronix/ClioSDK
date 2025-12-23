using Timer = ClioSDK.Models.Timer;
using Task = System.Threading.Tasks.Task;
using ClioSDK.Core;
using ClioSDK.Models;
using ClioSDK.Models.Requests;

namespace ClioSDK.Clients;

public class TimersClient : BaseClient
{

    public TimersClient(HttpClient httpClient) : base(httpClient, "timers")
    {}

    public async System.Threading.Tasks.Task<PaginatedResponse<Timer>> GetAsync(QueryOptions? options = null)
    {
        return await GetListAsync<Timer>("", options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Timer>> GetAsync(int id, QueryOptions? options = null)
    {
        return await GetAsync<Timer>(id.ToString(), options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Timer>> CreateAsync(ClioSDK.Models.Requests.TimerRequest request)
    {
        return await CreateAsync<ClioSDK.Models.Requests.TimerRequest, Timer>("", request);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Timer>> UpdateAsync(int id, ClioSDK.Models.Requests.TimerRequest request)
    {
        return await UpdateAsync<ClioSDK.Models.Requests.TimerRequest, Timer>(id.ToString(), request);
    }

    public async System.Threading.Tasks.Task DeleteAsync(int id)
    {
        await DeleteAsync(id.ToString());
    }
}