using Task = System.Threading.Tasks.Task;
using ClioSDK.Core;
using ClioSDK.Models;
using ClioSDK.Models.Requests;

namespace ClioSDK.Clients;

public class CalendarsClient : BaseClient
{

    public CalendarsClient(HttpClient httpClient) : base(httpClient, "calendars")
    {
// _httpClient is managed by BaseClient
    }

    public async System.Threading.Tasks.Task<PaginatedResponse<Calendar>> GetAsync(QueryOptions? options = null)
    {
        return await GetListAsync<Calendar>("", options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Calendar>> GetAsync(int id, QueryOptions? options = null)
    {
        return await GetAsync<Calendar>(id.ToString(), options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Calendar>> CreateAsync(ClioSDK.Models.Requests.CalendarRequest request)
    {
        return await CreateAsync<ClioSDK.Models.Requests.CalendarRequest, Calendar>("", request);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Calendar>> UpdateAsync(int id, ClioSDK.Models.Requests.CalendarRequest request)
    {
        return await UpdateAsync<ClioSDK.Models.Requests.CalendarRequest, Calendar>(id.ToString(), request);
    }

    public async System.Threading.Tasks.Task DeleteAsync(int id)
    {
        await DeleteAsync(id.ToString());
    }
}