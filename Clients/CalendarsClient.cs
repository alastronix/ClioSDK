using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients;

public class CalendarsClient : BaseClient
{
    private readonly HttpClient _httpClient;

    public CalendarsClient(HttpClient httpClient) : base(httpClient, "calendars")
    {
        _httpClient = httpClient;
    }

    public async System.Threading.Tasks.Task<PaginatedResponse<Calendar>> GetAsync(QueryOptions? options = null)
    {
        return await GetListAsync<Calendar>("", options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Calendar>> GetAsync(int id, QueryOptions? options = null)
    {
        return await GetAsync<Calendar>(id.ToString(), options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Calendar>> CreateAsync(CalendarRequest request)
    {
        return await CreateAsync<Calendar>("", request);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Calendar>> UpdateAsync(int id, CalendarRequest request)
    {
        return await UpdateAsync<Calendar>(id.ToString(), request);
    }

    public async System.Threading.Tasks.Task DeleteAsync(int id)
    {
        await DeleteAsync(id.ToString());
    }
}