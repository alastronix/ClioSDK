using Task = System.Threading.Tasks.Task;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients;

public class DocumentsClient : BaseClient
{
    private readonly HttpClient _httpClient;

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

    public async System.Threading.Tasks.Task<ApiResponse<Document>> CreateAsync(DocumentRequest request)
    {
        return await CreateAsync<Document>("", request);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Document>> UpdateAsync(int id, DocumentRequest request)
    {
        return await UpdateAsync<Document>(id.ToString(), request);
    }

    public async System.Threading.Tasks.Task DeleteAsync(int id)
    {
        await DeleteAsync(id.ToString());
    }
}