using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients;

public class TextSnippetsClient : BaseClient
{
    private readonly HttpClient _httpClient;

    public TextSnippetsClient(HttpClient httpClient) : base(httpClient, "textsnippets")
    {
        _httpClient = httpClient;
    }

    public async System.Threading.Tasks.Task<PaginatedResponse<TextSnippet>> GetAsync(QueryOptions? options = null)
    {
        return await GetListAsync<TextSnippet>("", options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<TextSnippet>> GetAsync(int id, QueryOptions? options = null)
    {
        return await GetAsync<TextSnippet>(id.ToString(), options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<TextSnippet>> CreateAsync(TextSnippetRequest request)
    {
        return await CreateAsync<TextSnippet>("", request);
    }

    public async System.Threading.Tasks.Task<ApiResponse<TextSnippet>> UpdateAsync(int id, TextSnippetRequest request)
    {
        return await UpdateAsync<TextSnippet>(id.ToString(), request);
    }

    public async System.Threading.Tasks.Task DeleteAsync(int id)
    {
        await DeleteAsync(id.ToString());
    }
}