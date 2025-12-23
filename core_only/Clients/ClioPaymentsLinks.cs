using Task = System.Threading.Tasks.Task;
using ClioSDK.Core;
using ClioSDK.Models;
using ClioSDK.Models.Requests;

namespace ClioSDK.Clients;

public class ClioPaymentsLinksClient : BaseClient
{
    private readonly HttpClient _httpClient;

    public ClioPaymentsLinksClient(HttpClient httpClient) : base(httpClient, "cliopaymentslinks")
    {
        _httpClient = httpClient;
    }

    public async System.Threading.Tasks.Task<PaginatedResponse<ClioPaymentsLink>> GetAsync(QueryOptions? options = null)
    {
        return await GetListAsync<ClioPaymentsLink>("", options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<ClioPaymentsLink>> GetAsync(int id, QueryOptions? options = null)
    {
        return await GetAsync<ClioPaymentsLink>(id.ToString(), options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<ClioPaymentsLink>> CreateAsync(ClioSDK.Models.Requests.ClioPaymentsLinkRequest request)
    {
        return await CreateAsync<ClioSDK.Models.Requests.ClioPaymentsLinkRequest, ClioPaymentsLink>("", request);
    }

    public async System.Threading.Tasks.Task<ApiResponse<ClioPaymentsLink>> UpdateAsync(int id, ClioSDK.Models.Requests.ClioPaymentsLinkRequest request)
    {
        return await UpdateAsync<ClioSDK.Models.Requests.ClioPaymentsLinkRequest, ClioPaymentsLink>(id.ToString(), request);
    }

    public async System.Threading.Tasks.Task DeleteAsync(int id)
    {
        await DeleteAsync(id.ToString());
    }
}