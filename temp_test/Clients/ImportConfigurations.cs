using Task = System.Threading.Tasks.Task;
using ClioSDK.Core;
using ClioSDK.Models;
using ClioSDK.Models.Requests;

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

    public async System.Threading.Tasks.Task<ApiResponse<ImportConfiguration>> CreateAsync(ClioSDK.Models.Requests.ImportConfigurationRequest request)
    {
        return await CreateAsync<ClioSDK.Models.Requests.ImportConfigurationRequest, ImportConfiguration>("", request);
    }

    public async System.Threading.Tasks.Task<ApiResponse<ImportConfiguration>> UpdateAsync(int id, ClioSDK.Models.Requests.ImportConfigurationRequest request)
    {
        return await UpdateAsync<ClioSDK.Models.Requests.ImportConfigurationRequest, ImportConfiguration>(id.ToString(), request);
    }

    public async System.Threading.Tasks.Task DeleteAsync(int id)
    {
        await DeleteAsync(id.ToString());
    }
}