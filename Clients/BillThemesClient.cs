using Task = System.Threading.Tasks.Task;
using ClioSDK.Core;
using ClioSDK.Models;
using ClioSDK.Models.Requests;

namespace ClioSDK.Clients;

public class BillThemesClient : BaseClient
{

    public BillThemesClient(HttpClient httpClient) : base(httpClient, "bill_themes")
    {
// _httpClient is managed by BaseClient
    }

    public async System.Threading.Tasks.Task<PaginatedResponse<BillTheme>> GetAsync(QueryOptions? options = null)
    {
        return await GetListAsync<BillTheme>("", options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<BillTheme>> GetAsync(int id, QueryOptions? options = null)
    {
        return await GetAsync<BillTheme>(id.ToString(), options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<BillTheme>> CreateAsync(ClioSDK.Models.Requests.BillThemeRequest request)
    {
        return await CreateAsync<ClioSDK.Models.Requests.BillThemeRequest, BillTheme>("", request);
    }

    public async System.Threading.Tasks.Task<ApiResponse<BillTheme>> UpdateAsync(int id, ClioSDK.Models.Requests.BillThemeRequest request)
    {
        return await UpdateAsync<ClioSDK.Models.Requests.BillThemeRequest, BillTheme>(id.ToString(), request);
    }

    public async System.Threading.Tasks.Task DeleteAsync(int id)
    {
        await DeleteAsync(id.ToString());
    }
}