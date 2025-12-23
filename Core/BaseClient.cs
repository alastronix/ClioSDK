using System.Text.Json;
using System.Net.Http.Json;

namespace ClioSDK.Core;

public abstract class BaseClient
{
    protected readonly HttpClient _httpClient;
    protected readonly string _baseEndpoint;
    protected readonly JsonSerializerOptions _jsonOptions;

    protected BaseClient(HttpClient httpClient, string baseEndpoint)
    {
        _httpClient = httpClient;
        _baseEndpoint = baseEndpoint;
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
        };
    }

    protected async Task<ApiResponse<T>> GetAsync<T>(string endpoint, QueryOptions? options = null)
    {
        var url = BuildUrl(endpoint, options);
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        
        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<ApiResponse<T>>(content, _jsonOptions);
        return result ?? throw new InvalidOperationException("Failed to deserialize response");
    }

    protected async Task<PaginatedResponse<T>> GetListAsync<T>(string endpoint, QueryOptions? options = null)
    {
        var url = BuildUrl(endpoint, options);
        var response = await _httpClient.GetAsync(url);
        response.EnsureSuccessStatusCode();
        
        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<PaginatedResponse<T>>(content, _jsonOptions);
        return result ?? throw new InvalidOperationException("Failed to deserialize response");
    }

    protected async Task<ApiResponse<T>> CreateAsync<T>(string endpoint, T data)
    {
        var url = BuildUrl(endpoint);
        var response = await _httpClient.PostAsJsonAsync(url, data, _jsonOptions);
        response.EnsureSuccessStatusCode();
        
        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<ApiResponse<T>>(content, _jsonOptions);
        return result ?? throw new InvalidOperationException("Failed to deserialize response");
    }

    protected async Task<ApiResponse<T>> UpdateAsync<T>(string endpoint, T data)
    {
        var url = BuildUrl(endpoint);
        var response = await _httpClient.PutAsJsonAsync(url, data, _jsonOptions);
        response.EnsureSuccessStatusCode();
        
        var content = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<ApiResponse<T>>(content, _jsonOptions);
        return result ?? throw new InvalidOperationException("Failed to deserialize response");
    }

    protected async Task DeleteAsync(string endpoint)
    {
        var url = BuildUrl(endpoint);
        var response = await _httpClient.DeleteAsync(url);
        response.EnsureSuccessStatusCode();
    }

    private string BuildUrl(string endpoint, QueryOptions? options = null)
    {
        var url = $"{_baseEndpoint}/{endpoint}";
        
        if (options != null)
        {
            var queryParams = new List<string>();
            
            if (options.Limit.HasValue)
                queryParams.Add($"limit={options.Limit.Value}");
            
            if (options.Offset.HasValue)
                queryParams.Add($"offset={options.Offset.Value}");
            
            if (!string.IsNullOrEmpty(options.Order))
                queryParams.Add($"order={Uri.EscapeDataString(options.Order)}");
            
            if (!string.IsNullOrEmpty(options.Fields))
                queryParams.Add($"fields={Uri.EscapeDataString(options.Fields)}");

            if (options.Query?.Any() == true)
            {
                foreach (var kvp in options.Query)
                {
                    queryParams.Add($"{kvp.Key}={Uri.EscapeDataString(kvp.Value.ToString())}");
                }
            }

            if (queryParams.Any())
                url += "?" + string.Join("&", queryParams);
        }

        return url;
    }
}

public class ApiException : Exception
{
    public int StatusCode { get; }
    public string? ErrorDetails { get; }

    public ApiException(int statusCode, string message, string? errorDetails = null) : base(message)
    {
        StatusCode = statusCode;
        ErrorDetails = errorDetails;
    }
}