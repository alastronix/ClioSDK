using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients;

public class BillsClient : BaseClient
{
    private readonly HttpClient _httpClient;

    public BillsClient(HttpClient httpClient) : base(httpClient, "bills")
    {
        _httpClient = httpClient;
    }

    public async System.Threading.Tasks.Task<PaginatedResponse<Bill>> GetAsync(QueryOptions? options = null)
    {
        return await GetListAsync<Bill>("", options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Bill>> GetAsync(int id, QueryOptions? options = null)
    {
        return await GetAsync<Bill>(id.ToString(), options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Bill>> UpdateAsync(int id, BillRequest request)
    {
        return await UpdateAsync<Bill>(id.ToString(), request);
    }

    public async System.Threading.Tasks.Task DeleteAsync(int id)
    {
        await DeleteAsync(id.ToString());
    }
}