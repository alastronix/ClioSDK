using Task = System.Threading.Tasks.Task;
using ClioSDK.Core;
using ClioSDK.Models;
using ClioSDK.Models.Requests;

namespace ClioSDK.Clients;

public class ExpenseCategoriesClient : BaseClient
{
    private readonly HttpClient _httpClient;

    public ExpenseCategoriesClient(HttpClient httpClient) : base(httpClient, "expensecategories")
    {
        _httpClient = httpClient;
    }

    public async System.Threading.Tasks.Task<PaginatedResponse<ExpenseCategorie>> GetAsync(QueryOptions? options = null)
    {
        return await GetListAsync<ExpenseCategorie>("", options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<ExpenseCategorie>> GetAsync(int id, QueryOptions? options = null)
    {
        return await GetAsync<ExpenseCategorie>(id.ToString(), options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<ExpenseCategorie>> CreateAsync(ClioSDK.Models.Requests.ExpenseCategorieRequest request)
    {
        return await CreateAsync<ClioSDK.Models.Requests.ExpenseCategorieRequest, ExpenseCategorie>("", request);
    }

    public async System.Threading.Tasks.Task<ApiResponse<ExpenseCategorie>> UpdateAsync(int id, ClioSDK.Models.Requests.ExpenseCategorieRequest request)
    {
        return await UpdateAsync<ClioSDK.Models.Requests.ExpenseCategorieRequest, ExpenseCategorie>(id.ToString(), request);
    }

    public async System.Threading.Tasks.Task DeleteAsync(int id)
    {
        await DeleteAsync(id.ToString());
    }
}