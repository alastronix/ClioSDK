using Task = System.Threading.Tasks.Task;
using ClioSDK.Core;
using ClioSDK.Models;
using ClioSDK.Models.Requests;

namespace ClioSDK.Clients;

public class BankAccountsClient : BaseClient
{
    public BankAccountsClient(HttpClient httpClient) : base(httpClient, "bank_accounts")
    {}

    public async System.Threading.Tasks.Task<PaginatedResponse<BankAccount>> GetAsync(QueryOptions? options = null)
    {
        return await GetListAsync<BankAccount>("", options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<BankAccount>> GetAsync(int id, QueryOptions? options = null)
    {
        return await GetAsync<BankAccount>(id.ToString(), options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<BankAccount>> CreateAsync(ClioSDK.Models.Requests.BankAccountRequest request)
    {
        return await CreateAsync<ClioSDK.Models.Requests.BankAccountRequest, BankAccount>("", request);
    }

    public async System.Threading.Tasks.Task<ApiResponse<BankAccount>> UpdateAsync(int id, ClioSDK.Models.Requests.BankAccountRequest request)
    {
        return await UpdateAsync<ClioSDK.Models.Requests.BankAccountRequest, BankAccount>(id.ToString(), request);
    }

    public async System.Threading.Tasks.Task DeleteAsync(int id)
    {
        await DeleteAsync(id.ToString());
    }
}