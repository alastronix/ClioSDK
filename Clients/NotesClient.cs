using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients;

public class NotesClient : BaseClient
{
    private readonly HttpClient _httpClient;

    public NotesClient(HttpClient httpClient) : base(httpClient, "notes")
    {
        _httpClient = httpClient;
    }

    public async System.Threading.Tasks.Task<PaginatedResponse<Note>> GetAsync(QueryOptions? options = null)
    {
        return await GetListAsync<Note>("", options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Note>> GetAsync(int id, QueryOptions? options = null)
    {
        return await GetAsync<Note>(id.ToString(), options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Note>> CreateAsync(NoteRequest request)
    {
        return await CreateAsync<Note>("", request);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Note>> UpdateAsync(int id, NoteRequest request)
    {
        return await UpdateAsync<Note>(id.ToString(), request);
    }

    public async System.Threading.Tasks.Task DeleteAsync(int id)
    {
        await DeleteAsync(id.ToString());
    }
}