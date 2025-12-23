using ClioSDK.Core;
using ClioSDK.Models;

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

    public async System.Threading.Tasks.Task<ApiResponse<Contact>> CreateAsync(ContactRequest request)
    {
        return await CreateAsync<Contact>("", request);
    }

    public async System.Threading.Tasks.Task<ApiResponse<Contact>> UpdateAsync(int id, ContactRequest request)
    {
        return await UpdateAsync<Contact>(id.ToString(), request);
    }

    public async System.Threading.Tasks.Task DeleteAsync(int id)
    {
        await DeleteAsync(id.ToString());
    }
}