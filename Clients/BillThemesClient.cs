using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients;

public class BillThemesClient : BaseClient
{
    private readonly HttpClient _httpClient;

    public BillThemesClient(HttpClient httpClient) : base(httpClient, "bill_themes")
    {
        _httpClient = httpClient;
    }

    public async System.Threading.Tasks.Task<PaginatedResponse<BillTheme>> GetAsync(QueryOptions? options = null)
    {
        return await GetListAsync<BillTheme>("", options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<BillTheme>> GetAsync(int id, QueryOptions? options = null)
    {
        return await GetAsync<BillTheme>(id.ToString(), options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<BillTheme>> CreateAsync(BillThemeRequest request)
    {
        return await CreateAsync<BillTheme>("", request);
    }

    public async System.Threading.Tasks.Task<ApiResponse<BillTheme>> UpdateAsync(int id, BillThemeRequest request)
    {
        return await UpdateAsync<BillTheme>(id.ToString(), request);
    }

    public async System.Threading.Tasks.Task DeleteAsync(int id)
    {
        await DeleteAsync(id.ToString());
    }
}