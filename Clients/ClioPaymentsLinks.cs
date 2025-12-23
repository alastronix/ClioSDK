using Task = System.Threading.Tasks.Task;
using ClioSDK.Core;
using ClioSDK.Models;

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

    public async System.Threading.Tasks.Task<ApiResponse<ClioPaymentsLink>> CreateAsync(ClioPaymentsLinkRequest request)
    {
        return await CreateAsync<ClioPaymentsLink>("", request);
    }

    public async System.Threading.Tasks.Task<ApiResponse<ClioPaymentsLink>> UpdateAsync(int id, ClioPaymentsLinkRequest request)
    {
        return await UpdateAsync<ClioPaymentsLink>(id.ToString(), request);
    }

    public async System.Threading.Tasks.Task DeleteAsync(int id)
    {
        await DeleteAsync(id.ToString());
    }
}