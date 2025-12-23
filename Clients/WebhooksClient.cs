using Task = System.Threading.Tasks.Task;
using ClioSDK.Core;
using ClioSDK.Models;
using ClioSDK.Models.Requests;

namespace ClioSDK.Clients;

public class WebhooksClient : BaseClient
{

    public WebhooksClient(HttpClient httpClient) : base(httpClient, "webhooks")
    {
        _httpClient = httpClient;
    }

    public async System.Threading.Tasks.Task<PaginatedResponse<Webhook>> GetAsync(QueryOptions? options = null)
    {
        return await GetListAsync<Webhook>("", options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Webhook>> GetAsync(int id, QueryOptions? options = null)
    {
        return await GetAsync<Webhook>(id.ToString(), options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Webhook>> CreateAsync(ClioSDK.Models.Requests.WebhookRequest request)
    {
        return await CreateAsync<ClioSDK.Models.Requests.WebhookRequest, Webhook>("", request);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Webhook>> UpdateAsync(int id, ClioSDK.Models.Requests.WebhookRequest request)
    {
        return await UpdateAsync<ClioSDK.Models.Requests.WebhookRequest, Webhook>(id.ToString(), request);
    }

    public async System.Threading.Tasks.Task DeleteAsync(int id)
    {
        await DeleteAsync(id.ToString());
    }
}