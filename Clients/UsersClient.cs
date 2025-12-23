using Task = System.Threading.Tasks.Task;
using ClioSDK.Core;
using ClioSDK.Models;

namespace ClioSDK.Clients;

public class UsersClient : BaseClient
{

    public UsersClient(HttpClient httpClient) : base(httpClient, "users")
    {}

    public async System.Threading.Tasks.Task<PaginatedResponse<User>> GetAsync(QueryOptions? options = null)
    {
        return await GetListAsync<User>("", options);
    }

    public async System.Threading.Tasks.Task<ApiResponse<User>> GetAsync(int id, QueryOptions? options = null)
    {
        return await GetAsync<User>(id.ToString(), options);
    }
}