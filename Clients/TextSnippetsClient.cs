using Task = System.Threading.Tasks.Task;
using ClioSDK.Core;
using ClioSDK.Models;
using ClioSDK.Models.Requests;

namespace ClioSDK.Clients;

public class TextSnippetsClient : BaseClient
{
    public TextSnippetsClient(HttpClient httpClient) : base(httpClient, "textsnippets")
    {}

    public async System.Threading.Tasks.Task<PaginatedResponse<TextSnippet>> GetAsync(QueryOptions? options = null)
    {
        return await GetListAsync<TextSnippet>("", options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<TextSnippet>> GetAsync(int id, QueryOptions? options = null)
    {
        return await GetAsync<TextSnippet>(id.ToString(), options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<TextSnippet>> CreateAsync(ClioSDK.Models.Requests.TextSnippetRequest request)
    {
        return await CreateAsync<ClioSDK.Models.Requests.TextSnippetRequest, TextSnippet>("", request);
    }

    public async System.Threading.Tasks.Task<ApiResponse<TextSnippet>> UpdateAsync(int id, ClioSDK.Models.Requests.TextSnippetRequest request)
    {
        return await UpdateAsync<ClioSDK.Models.Requests.TextSnippetRequest, TextSnippet>(id.ToString(), request);
    }

    public async System.Threading.Tasks.Task DeleteAsync(int id)
    {
        await DeleteAsync(id.ToString());
    }
}