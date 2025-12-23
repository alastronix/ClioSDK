using Task = System.Threading.Tasks.Task;
using ClioSDK.Core;
using ClioSDK.Models;
using ClioSDK.Models.Requests;

namespace ClioSDK.Clients;

public class NotesClient : BaseClient
{

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

    public async System.Threading.Tasks.Task<ApiResponse<Note>> CreateAsync(ClioSDK.Models.Requests.NoteRequest request)
    {
        return await CreateAsync<ClioSDK.Models.Requests.NoteRequest, Note>("", request);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Note>> UpdateAsync(int id, ClioSDK.Models.Requests.NoteRequest request)
    {
        return await UpdateAsync<ClioSDK.Models.Requests.NoteRequest, Note>(id.ToString(), request);
    }

    public async System.Threading.Tasks.Task DeleteAsync(int id)
    {
        await DeleteAsync(id.ToString());
    }
}