using Task = System.Threading.Tasks.Task;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients;

public class CustomFieldsClient : BaseClient
{

    public CustomFieldsClient(HttpClient httpClient) : base(httpClient, "custom_fields")
    {
        _httpClient = httpClient;
    }

    public async System.Threading.Tasks.Task<PaginatedResponse<CustomField>> GetAsync(QueryOptions? options = null)
    {
        return await GetListAsync<CustomField>("", options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<CustomField>> GetAsync(int id, QueryOptions? options = null)
    {
        return await GetAsync<CustomField>(id.ToString(), options);
    }
}

public class CustomFieldSetsClient : BaseClient
{

    public CustomFieldSetsClient(HttpClient httpClient) : base(httpClient, "custom_field_sets")
    {
        _httpClient = httpClient;
    }

    public async System.Threading.Tasks.Task<PaginatedResponse<CustomFieldSet>> GetAsync(QueryOptions? options = null)
    {
        return await GetListAsync<CustomFieldSet>("", options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<CustomFieldSet>> GetAsync(int id, QueryOptions? options = null)
    {
        return await GetAsync<CustomFieldSet>(id.ToString(), options);
    }
}