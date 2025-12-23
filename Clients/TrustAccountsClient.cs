using Task = System.Threading.Tasks.Task;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients;

public class TrustAccountsClient : BaseClient
{
    private readonly HttpClient _httpClient;

    public TrustAccountsClient(HttpClient httpClient) : base(httpClient, "trust_accounts")
    {
        _httpClient = httpClient;
    }

    public async System.Threading.Tasks.Task<PaginatedResponse<TrustAccount>> GetAsync(QueryOptions? options = null)
    {
        return await GetListAsync<TrustAccount>("", options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<TrustAccount>> GetAsync(int id, QueryOptions? options = null)
    {
        return await GetAsync<TrustAccount>(id.ToString(), options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<TrustAccount>> CreateAsync(TrustAccountRequest request)
    {
        return await CreateAsync<TrustAccount>("", request);
    }

    public async System.Threading.Tasks.Task<ApiResponse<TrustAccount>> UpdateAsync(int id, TrustAccountRequest request)
    {
        return await UpdateAsync<TrustAccount>(id.ToString(), request);
    }

    public async System.Threading.Tasks.Task DeleteAsync(int id)
    {
        await DeleteAsync(id.ToString());
    }
}