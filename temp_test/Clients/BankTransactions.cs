using Task = System.Threading.Tasks.Task;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients;

public class BankTransactionsClient : BaseClient
{
    private readonly HttpClient _httpClient;

    public BankTransactionsClient(HttpClient httpClient) : base(httpClient, "banktransactions")
    {
        _httpClient = httpClient;
    }

    public async System.Threading.Tasks.Task<PaginatedResponse<BankTransaction>> GetAsync(QueryOptions? options = null)
    {
        return await GetListAsync<BankTransaction>("", options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<BankTransaction>> GetAsync(int id, QueryOptions? options = null)
    {
        return await GetAsync<BankTransaction>(id.ToString(), options);
    }
}