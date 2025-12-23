using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients;

public class PracticeAreasClient : BaseClient
{
    private readonly HttpClient _httpClient;

    public PracticeAreasClient(HttpClient httpClient) : base(httpClient, "practiceareas")
    {
        _httpClient = httpClient;
    }

    public async System.Threading.Tasks.Task<PaginatedResponse<PracticeArea>> GetAsync(QueryOptions? options = null)
    {
        return await GetListAsync<PracticeArea>("", options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<PracticeArea>> GetAsync(int id, QueryOptions? options = null)
    {
        return await GetAsync<PracticeArea>(id.ToString(), options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<PracticeArea>> CreateAsync(PracticeAreaRequest request)
    {
        return await CreateAsync<PracticeArea>("", request);
    }

    public async System.Threading.Tasks.Task<ApiResponse<PracticeArea>> UpdateAsync(int id, PracticeAreaRequest request)
    {
        return await UpdateAsync<PracticeArea>(id.ToString(), request);
    }

    public async System.Threading.Tasks.Task DeleteAsync(int id)
    {
        await DeleteAsync(id.ToString());
    }
}