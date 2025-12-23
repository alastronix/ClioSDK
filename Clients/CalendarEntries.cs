using Task = System.Threading.Tasks.Task;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients;

public class CalendarEntriesClient : BaseClient
{
    private readonly HttpClient _httpClient;

    public CalendarEntriesClient(HttpClient httpClient) : base(httpClient, "calendarentries")
    {
        _httpClient = httpClient;
    }

    public async System.Threading.Tasks.Task<PaginatedResponse<CalendarEntrie>> GetAsync(QueryOptions? options = null)
    {
        return await GetListAsync<CalendarEntrie>("", options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<CalendarEntrie>> GetAsync(int id, QueryOptions? options = null)
    {
        return await GetAsync<CalendarEntrie>(id.ToString(), options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<CalendarEntrie>> CreateAsync(CalendarEntrieRequest request)
    {
        return await CreateAsync<CalendarEntrie>("", request);
    }

    public async System.Threading.Tasks.Task<ApiResponse<CalendarEntrie>> UpdateAsync(int id, CalendarEntrieRequest request)
    {
        return await UpdateAsync<CalendarEntrie>(id.ToString(), request);
    }

    public async System.Threading.Tasks.Task DeleteAsync(int id)
    {
        await DeleteAsync(id.ToString());
    }
}