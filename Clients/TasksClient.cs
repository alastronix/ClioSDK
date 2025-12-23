using Task = System.Threading.Tasks.Task;
using ClioSDK.Core;
using ClioSDK.Models;
using ClioSDK.Models.Requests;

namespace ClioSDK.Clients;

public class TasksClient : BaseClient
{

    public TasksClient(HttpClient httpClient) : base(httpClient, "tasks")
    {}

    public async System.Threading.Tasks.Task<PaginatedResponse<Task>> GetAsync(QueryOptions? options = null)
    {
        return await GetListAsync<Task>("", options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Task>> GetAsync(int id, QueryOptions? options = null)
    {
        return await GetAsync<Task>(id.ToString(), options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Task>> CreateAsync(ClioSDK.Models.Requests.TaskRequest request)
    {
        return await CreateAsync<ClioSDK.Models.Requests.TaskRequest, Task>("", request);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Task>> UpdateAsync(int id, ClioSDK.Models.Requests.TaskRequest request)
    {
        return await UpdateAsync<ClioSDK.Models.Requests.TaskRequest, Task>(id.ToString(), request);
    }

    public async System.Threading.Tasks.Task DeleteAsync(int id)
    {
        await DeleteAsync(id.ToString());
    }
}