using Task = System.Threading.Tasks.Task;
using ClioSDK.Core;
using ClioSDK.Models;
using ClioSDK.Models.Requests;

namespace ClioSDK.Clients;

public class MattersClient : BaseClient
{
    private readonly HttpClient _httpClient;

    public MattersClient(HttpClient httpClient) : base(httpClient, "matters")
    {
        _httpClient = httpClient;
    }

    public async System.Threading.Tasks.Task<PaginatedResponse<Matter>> GetAsync(QueryOptions? options = null)
    {
        return await GetListAsync<Matter>("", options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Matter>> GetAsync(int id, QueryOptions? options = null)
    {
        return await GetAsync<Matter>(id.ToString(), options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Matter>> CreateAsync(ClioSDK.Models.Requests.MatterRequest request)
    {
        return await CreateAsync<ClioSDK.Models.Requests.MatterRequest, Matter>("", request);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Matter>> UpdateAsync(int id, ClioSDK.Models.Requests.MatterRequest request)
    {
        return await UpdateAsync<ClioSDK.Models.Requests.MatterRequest, Matter>(id.ToString(), request);
    }

    public async System.Threading.Tasks.Task DeleteAsync(int id)
    {
        await DeleteAsync(id.ToString());
    }
}