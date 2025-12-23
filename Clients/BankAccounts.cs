using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients;

public class BankAccountsClient : BaseClient
{
    private readonly HttpClient _httpClient;

    public BankAccountsClient(HttpClient httpClient) : base(httpClient, "bank_accounts")
    {
        _httpClient = httpClient;
    }

    public async System.Threading.Tasks.Task<PaginatedResponse<BankAccount>> GetAsync(QueryOptions? options = null)
    {
        return await GetListAsync<BankAccount>("", options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<BankAccount>> GetAsync(int id, QueryOptions? options = null)
    {
        return await GetAsync<BankAccount>(id.ToString(), options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<BankAccount>> CreateAsync(BankAccountRequest request)
    {
        return await CreateAsync<BankAccount>("", request);
    }

    public async System.Threading.Tasks.Task<ApiResponse<BankAccount>> UpdateAsync(int id, BankAccountRequest request)
    {
        return await UpdateAsync<BankAccount>(id.ToString(), request);
    }

    public async System.Threading.Tasks.Task DeleteAsync(int id)
    {
        await DeleteAsync(id.ToString());
    }
}