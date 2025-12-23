using System.Net;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Moq.Protected;
using ClioSDK.Core;
using ClioSDK.Models.Requests;

namespace ClioSDK.Tests.TestHelpers;

public abstract class TestBase
{
    protected Mock<HttpMessageHandler> MockHttpHandler { get; private set; }
    protected HttpClient HttpClient { get; private set; }
    protected Mock<BaseClient> MockBaseClient { get; private set; }

    protected TestBase()
    {
        SetupTestInfrastructure();
    }

    private void SetupTestInfrastructure()
    {
        // Setup HTTP client with mock handler
        MockHttpHandler = new Mock<HttpMessageHandler>();
        HttpClient = new HttpClient(MockHttpHandler.Object)
        {
            BaseAddress = new Uri("https://app.clio.com/api/v4/")
        };

        // Setup mock base client
        MockBaseClient = new Mock<BaseClient>(HttpClient, "test-endpoint");
    }

    protected void SetupMockResponse<T>(T response, HttpStatusCode statusCode = HttpStatusCode.OK)
    {
        var jsonResponse = JsonSerializer.Serialize(response, new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        var httpResponse = new HttpResponseMessage(statusCode)
        {
            Content = new StringContent(jsonResponse)
        };

        MockHttpHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(httpResponse);
    }

    protected void SetupMockErrorResponse(HttpStatusCode statusCode, string content = "Error message")
    {
        var httpResponse = new HttpResponseMessage(statusCode)
        {
            Content = new StringContent($"{{&quot;error&quot;: &quot;{content}&quot;}}")
        };

        MockHttpHandler
            .Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(httpResponse);
    }

    protected T CreateTestData<T>(Action<T>? configure = null) where T : class, new()
    {
        var data = new T();
        configure?.Invoke(data);
        return data;
    }

    protected List<T> CreateTestDataList<T>(int count, Func<int, T>? factory = null) where T : class, new()
    {
        var list = new List<T>();
        for (int i = 1; i <= count; i++)
        {
            var item = factory?.Invoke(i) ?? new T();
            list.Add(item);
        }
        return list;
    }
}