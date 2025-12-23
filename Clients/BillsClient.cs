using Task = System.Threading.Tasks.Task;
using ClioSDK.Core;
using ClioSDK.Models;
using ClioSDK.Models.Requests;

namespace ClioSDK.Clients;

public class BillsClient : BaseClient
{

    public BillsClient(HttpClient httpClient) : base(httpClient, "bills")
    {}

    public async System.Threading.Tasks.Task<PaginatedResponse<Bill>> GetAsync(QueryOptions? options = null)
    {
        return await GetListAsync<Bill>("", options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Bill>> GetAsync(int id, QueryOptions? options = null)
    {
        return await GetAsync<Bill>(id.ToString(), options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Bill>> UpdateAsync(int id, ClioSDK.Models.Requests.BillRequest request)
    {
        return await UpdateAsync<ClioSDK.Models.Requests.BillRequest, Bill>(id.ToString(), request);
    }

    public async System.Threading.Tasks.Task DeleteAsync(int id)
    {
        await DeleteAsync(id.ToString());
    }
}