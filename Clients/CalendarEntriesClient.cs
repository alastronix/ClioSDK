using Task = System.Threading.Tasks.Task;
using ClioSDK.Core;
using ClioSDK.Models;
using ClioSDK.Models.Requests;

namespace ClioSDK.Clients;

public class CalendarEntriesClient : BaseClient
{
    public CalendarEntriesClient(HttpClient httpClient) : base(httpClient, "calendarentries")
    {}

    public async System.Threading.Tasks.Task<PaginatedResponse<CalendarEntrie>> GetAsync(QueryOptions? options = null)
    {
        return await GetListAsync<CalendarEntrie>("", options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<CalendarEntrie>> GetAsync(int id, QueryOptions? options = null)
    {
        return await GetAsync<CalendarEntrie>(id.ToString(), options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<CalendarEntrie>> CreateAsync(ClioSDK.Models.Requests.CalendarEntrieRequest request)
    {
        return await CreateAsync<ClioSDK.Models.Requests.CalendarEntrieRequest, CalendarEntrie>("", request);
    }

    public async System.Threading.Tasks.Task<ApiResponse<CalendarEntrie>> UpdateAsync(int id, ClioSDK.Models.Requests.CalendarEntrieRequest request)
    {
        return await UpdateAsync<ClioSDK.Models.Requests.CalendarEntrieRequest, CalendarEntrie>(id.ToString(), request);
    }

    public async System.Threading.Tasks.Task DeleteAsync(int id)
    {
        await DeleteAsync(id.ToString());
    }
}