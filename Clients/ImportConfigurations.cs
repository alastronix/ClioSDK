using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients;

public class ImportConfigurationsClient : BaseClient
{
    private readonly HttpClient _httpClient;

    public ImportConfigurationsClient(HttpClient httpClient) : base(httpClient, "importconfigurations")
    {
        _httpClient = httpClient;
    }

    public async System.Threading.Tasks.Task<PaginatedResponse<ImportConfiguration>> GetAsync(QueryOptions? options = null)
    {
        return await GetListAsync<ImportConfiguration>("", options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<ImportConfiguration>> GetAsync(int id, QueryOptions? options = null)
    {
        return await GetAsync<ImportConfiguration>(id.ToString(), options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<ImportConfiguration>> CreateAsync(ImportConfigurationRequest request)
    {
        return await CreateAsync<ImportConfiguration>("", request);
    }

    public async System.Threading.Tasks.Task<ApiResponse<ImportConfiguration>> UpdateAsync(int id, ImportConfigurationRequest request)
    {
        return await UpdateAsync<ImportConfiguration>(id.ToString(), request);
    }

    public async System.Threading.Tasks.Task DeleteAsync(int id)
    {
        await DeleteAsync(id.ToString());
    }
}