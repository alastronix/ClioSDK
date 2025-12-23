using Task = System.Threading.Tasks.Task;
using ClioSDK.Core;
using ClioSDK.Models;
using ClioSDK.Models.Requests;

namespace ClioSDK.Clients;

public class ContactsClient : BaseClient
{
    private readonly HttpClient _httpClient;

    public ContactsClient(HttpClient httpClient) : base(httpClient, "contacts")
    {
        _httpClient = httpClient;
    }

    public async System.Threading.Tasks.Task<PaginatedResponse<Contact>> GetAsync(QueryOptions? options = null)
    {
        return await GetListAsync<Contact>("", options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Contact>> GetAsync(int id, QueryOptions? options = null)
    {
        return await GetAsync<Contact>(id.ToString(), options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Contact>> CreateAsync(ClioSDK.Models.Requests.ContactRequest request)
    {
        return await CreateAsync<ClioSDK.Models.Requests.ContactRequest, Contact>("", request);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Contact>> UpdateAsync(int id, ClioSDK.Models.Requests.ContactRequest request)
    {
        return await UpdateAsync<ClioSDK.Models.Requests.ContactRequest, Contact>(id.ToString(), request);
    }

    public async System.Threading.Tasks.Task DeleteAsync(int id)
    {
        await DeleteAsync(id.ToString());
    }
}