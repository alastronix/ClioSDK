using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ClioSDK.Clients;
using ClioSDK.Models;
using ClioSDK.Models.Requests;
using FluentAssertions;
using Xunit;
using Moq;
using System.Text.Json;

namespace ClioSDK.Tests.Clients
{
    public class SimpleActivitiesClientTests
    {
        private readonly Mock<HttpMessageHandler> _mockHandler;
        private readonly HttpClient _httpClient;
        private readonly ActivitiesClient _client;

        public SimpleActivitiesClientTests()
        {
            _mockHandler = new Mock<HttpMessageHandler>();
            _httpClient = new HttpClient(_mockHandler.Object);
            _client = new ActivitiesClient(_httpClient);
        }

        [Fact]
        public async Task GetAsync_ShouldReturnActivities_WhenCalled()
        {
            // Arrange
            var expectedActivities = new[]
            {
                new Activity { Id = 1, Description = "Test Activity 1" },
                new Activity { Id = 2, Description = "Test Activity 2" }
            };

            var responseContent = JsonSerializer.Serialize(new
            {
                data = expectedActivities,
                meta = new { total = 2 }
            });

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(responseContent)
            };

            _mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<System.Threading.CancellationToken>())
                .ReturnsAsync(response);

            // Act
            var result = await _client.GetAsync();

            // Assert
            result.Should().NotBeNull();
            result.Data.Should().HaveCount(2);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnActivity_WhenValidRequest()
        {
            // Arrange
            var request = new ActivityRequest
            {
                Description = "New Activity",
                Type = "TimeEntry"
            };

            var expectedActivity = new Activity 
            { 
                Id = 1, 
                Description = request.Description,
                Type = request.Type
            };

            var responseContent = JsonSerializer.Serialize(new
            {
                data = expectedActivity,
                meta = new { }
            });

            var response = new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new StringContent(responseContent)
            };

            _mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<System.Threading.CancellationToken>())
                .ReturnsAsync(response);

            // Act
            var result = await _client.CreateAsync(request);

            // Assert
            result.Should().NotBeNull();
            result.Data.Description.Should().Be(request.Description);
        }
    }
}