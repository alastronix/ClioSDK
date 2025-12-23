using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients;

public class WebhooksClient : BaseClient
{
    private readonly HttpClient _httpClient;

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

    public async System.Threading.Tasks.Task<ApiResponse<Webhook>> CreateAsync(WebhookRequest request)
    {
        return await CreateAsync<Webhook>("", request);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Webhook>> UpdateAsync(int id, WebhookRequest request)
    {
        return await UpdateAsync<Webhook>(id.ToString(), request);
    }

    public async System.Threading.Tasks.Task DeleteAsync(int id)
    {
        await DeleteAsync(id.ToString());
    }
}