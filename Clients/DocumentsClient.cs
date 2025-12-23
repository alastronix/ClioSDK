using Task = System.Threading.Tasks.Task;
using ClioSDK.Core;
using ClioSDK.Models;
using ClioSDK.Models.Requests;

namespace ClioSDK.Clients;

public class DocumentsClient : BaseClient
{

    public DocumentsClient(HttpClient httpClient) : base(httpClient, "documents")
    {
        _httpClient = httpClient;
    }

    public async System.Threading.Tasks.Task<PaginatedResponse<Document>> GetAsync(QueryOptions? options = null)
    {
        return await GetListAsync<Document>("", options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Document>> GetAsync(int id, QueryOptions? options = null)
    {
        return await GetAsync<Document>(id.ToString(), options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Document>> CreateAsync(ClioSDK.Models.Requests.DocumentRequest request)
    {
        return await CreateAsync<ClioSDK.Models.Requests.DocumentRequest, Document>("", request);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Document>> UpdateAsync(int id, ClioSDK.Models.Requests.DocumentRequest request)
    {
        return await UpdateAsync<ClioSDK.Models.Requests.DocumentRequest, Document>(id.ToString(), request);
    }

    public async System.Threading.Tasks.Task DeleteAsync(int id)
    {
        await DeleteAsync(id.ToString());
    }
}