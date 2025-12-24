using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using Moq;
using Moq.Protected;
using Xunit;

namespace ClioSDK.Tests
{
    /// <summary>
    /// Base class for all tests providing common setup and utilities
    /// </summary>
    public abstract class TestBase
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
        protected readonly HttpClient _httpClient;

        protected TestBase()
        {
            _httpMessageHandlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            _httpClient = new HttpClient(_httpMessageHandlerMock.Object)
            {
                BaseAddress = new Uri("https://app.clio.com/api/v4/")
            };

            var services = new ServiceCollection();
            services.AddHttpClient<ClioSDK.Clients.BaseClient>(client =>
            {
                client.BaseAddress = new Uri("https://app.clio.com/api/v4/");
            });

            _serviceProvider = services.BuildServiceProvider();
        }

        protected void SetupHttpResponse<T>(HttpStatusCode statusCode, T content)
        {
            var json = System.Text.Json.JsonSerializer.Serialize(content);
            var response = new HttpResponseMessage(statusCode)
            {
                Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json")
            };

            _httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);
        }

        protected void SetupErrorResponse(HttpStatusCode statusCode, string errorContent = "")
        {
            var response = new HttpResponseMessage(statusCode);
            if (!string.IsNullOrEmpty(errorContent))
            {
                response.Content = new StringContent(errorContent, System.Text.Encoding.UTF8, "application/json");
            }

            _httpMessageHandlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(response);
        }

        protected void VerifyHttpRequest(HttpMethod method, string expectedPath, Times times = default)
        {
            _httpMessageHandlerMock
                .Protected()
                .Verify(
                    "SendAsync",
                    times == default ? Times.Once() : times,
                    ItExpr.Is<HttpRequestMessage>(req => 
                        req.Method == method && 
                        req.RequestUri.ToString().Contains(expectedPath)),
                    ItExpr.IsAny<CancellationToken>());
        }
    }
}