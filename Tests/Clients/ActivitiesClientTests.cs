using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;
using ClioSDK.Clients;
using ClioSDK.Models;
using ClioSDK.Models.Requests;
using FluentAssertions;
using Xunit;
using Microsoft.Extensions.Http;

namespace ClioSDK.Tests.Clients;

public class ActivitiesClientTests : TestBase
{
    private readonly ActivitiesClient _client;

    public Tests() :
    base(TestSettings.ClioApiBaseUrl)
{

        _client = new ActivitiesClient(HttpClient);
    }

    #region GetAsync Tests
    [Fact]
    public async System.Threading.Tasks.Task GetAsync_ShouldReturnActivities_WhenCalled()
    {
        // Arrange
        var expectedActivities = TestDataFactory.CreateList(3, TestDataFactory.CreateActivity);
        var expectedResponse = TestDataFactory.CreatePaginatedResponse(expectedActivities);
        
        SetupMockResponse(expectedResponse);

        // Act
        var result = await _client.GetAsync();

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().HaveCount(3);
        VerifyHttpRequest("GET", "activities", Times.Once);
    }

    [Fact]
    public async System.Threading.Tasks.Task GetAsync_WithId_ShouldReturnSingleActivity()
    {
        // Arrange
        var expectedActivity = TestDataFactory.CreateActivity(123);
        var expectedResponse = TestDataFactory.CreateApiResponse(expectedActivity);
        
        SetupMockResponse(expectedResponse);

        // Act
        var result = await _client.GetAsync(123);

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().BeEquivalentTo(expectedActivity);
        VerifyHttpRequest("GET", "activities/123", Times.Once);
    }

    [Fact]
    public async System.Threading.Tasks.Task GetAsync_ShouldHandleErrorResponse()
    {
        // Arrange
        SetupMockErrorResponse(HttpStatusCode.Unauthorized, "Invalid API key");

        // Act & Assert
        await Assert.ThrowsAsync<HttpRequestException>(() => _client.GetAsync());
        VerifyHttpRequest("GET", "activities", Times.Once);
    }
    #endregion

    #region CreateAsync Tests
    [Fact]
    public async System.Threading.Tasks.Task CreateAsync_ShouldCreateActivity()
    {
        // Arrange
        var request = TestDataFactory.CreateActivityRequest();
        var expectedActivity = TestDataFactory.CreateActivity(123);
        var expectedResponse = TestDataFactory.CreateApiResponse(expectedActivity);

        SetupMockResponse(expectedResponse);

        // Act
        var result = await _client.CreateAsync(request);

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().BeEquivalentTo(expectedActivity);
        VerifyHttpRequest("POST", "activities", Times.Once);
    }

    [Fact]
    public async System.Threading.Tasks.Task CreateAsync_WithNullRequest_ShouldThrowArgumentNullException()
    {
        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => _client.CreateAsync(null!));
    }
    #endregion

    #region UpdateAsync Tests
    [Fact]
    public async System.Threading.Tasks.Task UpdateAsync_ShouldUpdateActivity()
    {
        // Arrange
        var request = TestDataFactory.CreateActivityRequest();
        var expectedActivity = TestDataFactory.CreateActivity(123);
        var expectedResponse = TestDataFactory.CreateApiResponse(expectedActivity);

        SetupMockResponse(expectedResponse);

        // Act
        var result = await _client.UpdateAsync(123, request);

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().BeEquivalentTo(expectedActivity);
        VerifyHttpRequest("PUT", "activities/123", Times.Once);
    }

    [Fact]
    public async System.Threading.Tasks.Task UpdateAsync_WithNullRequest_ShouldThrowArgumentNullException()
    {
        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => _client.UpdateAsync(123, null!));
    }
    #endregion

    #region DeleteAsync Tests
    [Fact]
    public async System.Threading.Tasks.Task DeleteAsync_ShouldDeleteActivity()
    {
        // Arrange
        var expectedResponse = TestDataFactory.CreateApiResponse(new { success = true });
        SetupMockResponse(expectedResponse);

        // Act
        await _client.DeleteAsync(123);

        // Assert
        VerifyHttpRequest("DELETE", "activities/123", Times.Once);
    }
    #endregion

    private void VerifyHttpRequest(string expectedMethod, string expectedPath, Times times)
    {
        MockHttpHandler
            .Protected()
            .Verify(
                "SendAsync",
                times,
                ItExpr.Is<HttpRequestMessage>(req => 
                    req.Method.ToString() == expectedMethod && 
                    req.RequestUri?.AbsolutePath.Contains(expectedPath) == true),
                ItExpr.IsAny<CancellationToken>());
    }
}