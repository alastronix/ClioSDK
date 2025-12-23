using Task = System.Threading.Tasks.Task;
using ClioSDK.Core;
using ClioSDK.Models;
using ClioSDK.Models.Requests;

namespace ClioSDK.Clients;

public class PracticeAreasClient : BaseClient
{
    public PracticeAreasClient(HttpClient httpClient) : base(httpClient, "practiceareas")
    {}

    public async System.Threading.Tasks.Task<PaginatedResponse<PracticeArea>> GetAsync(QueryOptions? options = null)
    {
        return await GetListAsync<PracticeArea>("", options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<PracticeArea>> GetAsync(int id, QueryOptions? options = null)
    {
        return await GetAsync<PracticeArea>(id.ToString(), options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<PracticeArea>> CreateAsync(ClioSDK.Models.Requests.PracticeAreaRequest request)
    {
        return await CreateAsync<ClioSDK.Models.Requests.PracticeAreaRequest, PracticeArea>("", request);
    }

    public async System.Threading.Tasks.Task<ApiResponse<PracticeArea>> UpdateAsync(int id, ClioSDK.Models.Requests.PracticeAreaRequest request)
    {
        return await UpdateAsync<ClioSDK.Models.Requests.PracticeAreaRequest, PracticeArea>(id.ToString(), request);
    }

    public async System.Threading.Tasks.Task DeleteAsync(int id)
    {
        await DeleteAsync(id.ToString());
    }
}