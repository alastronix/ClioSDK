using Task = System.Threading.Tasks.Task;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients;

public class LineItemsClient : BaseClient
{
    private readonly HttpClient _httpClient;

    public LineItemsClient(HttpClient httpClient) : base(httpClient, "lineitems")
    {
        _httpClient = httpClient;
    }

    public async System.Threading.Tasks.Task<PaginatedResponse<LineItem>> GetAsync(QueryOptions? options = null)
    {
        return await GetListAsync<LineItem>("", options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<LineItem>> GetAsync(int id, QueryOptions? options = null)
    {
        return await GetAsync<LineItem>(id.ToString(), options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<LineItem>> CreateAsync(LineItemRequest request)
    {
        return await CreateAsync<LineItem>("", request);
    }

    public async System.Threading.Tasks.Task<ApiResponse<LineItem>> UpdateAsync(int id, LineItemRequest request)
    {
        return await UpdateAsync<LineItem>(id.ToString(), request);
    }

    public async System.Threading.Tasks.Task DeleteAsync(int id)
    {
        await DeleteAsync(id.ToString());
    }
}