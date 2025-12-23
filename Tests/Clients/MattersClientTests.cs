using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;
using ClioSDK.Clients;
using ClioSDK.Models;
using ClioSDK.Models.Requests;
using ClioSDK.Tests.TestHelpers;
using FluentAssertions;
using Xunit;

namespace ClioSDK.Tests.Clients;

public class MattersClientTests : TestBase
{
    private readonly MattersClient _client;

    public MattersClientTests()
    {
        _client = new MattersClient(HttpClient);
    }

    #region GetAsync Tests
    [Fact]
    public async System.Threading.Tasks.Task GetAsync_ShouldReturnMatters_WhenCalled()
    {
        // Arrange
        var expectedMatters = TestDataFactory.CreateList(3, TestDataFactory.CreateMatter);
        var expectedResponse = TestDataFactory.CreatePaginatedResponse(expectedMatters);
        
        SetupMockResponse(expectedResponse);

        // Act
        var result = await _client.GetAsync();

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().HaveCount(3);
        result.Data.Should().BeEquivalentTo(expectedMatters);
        VerifyHttpRequest("GET", "matters", Times.Once);
    }

    [Fact]
    public async System.Threading.Tasks.Task GetAsync_WithId_ShouldReturnSingleMatter()
    {
        // Arrange
        var expectedMatter = TestDataFactory.CreateMatter(123);
        var expectedResponse = TestDataFactory.CreateApiResponse(expectedMatter);
        
        SetupMockResponse(expectedResponse);

        // Act
        var result = await _client.GetAsync(123);

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().BeEquivalentTo(expectedMatter);
        VerifyHttpRequest("GET", "matters/123", Times.Once);
    }

    [Fact]
    public async System.Threading.Tasks.Task GetAsync_ShouldHandleErrorResponse()
    {
        // Arrange
        SetupMockErrorResponse(HttpStatusCode.NotFound, "Matter not found");

        // Act & Assert
        await Assert.ThrowsAsync<HttpRequestException>(() => _client.GetAsync(999));
        VerifyHttpRequest("GET", "matters/999", Times.Once);
    }
    #endregion

    #region CreateAsync Tests
    [Fact]
    public async System.Threading.Tasks.Task CreateAsync_ShouldCreateMatter()
    {
        // Arrange
        var request = TestDataFactory.CreateMatterRequest();
        var expectedMatter = TestDataFactory.CreateMatter(123);
        var expectedResponse = TestDataFactory.CreateApiResponse(expectedMatter);

        SetupMockResponse(expectedResponse);

        // Act
        var result = await _client.CreateAsync(request);

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().BeEquivalentTo(expectedMatter);
        VerifyHttpRequest("POST", "matters", Times.Once);
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
    public async System.Threading.Tasks.Task UpdateAsync_ShouldUpdateMatter()
    {
        // Arrange
        var request = TestDataFactory.CreateMatterRequest();
        var expectedMatter = TestDataFactory.CreateMatter(123);
        var expectedResponse = TestDataFactory.CreateApiResponse(expectedMatter);

        SetupMockResponse(expectedResponse);

        // Act
        var result = await _client.UpdateAsync(123, request);

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().BeEquivalentTo(expectedMatter);
        VerifyHttpRequest("PUT", "matters/123", Times.Once);
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
    public async System.Threading.Tasks.Task DeleteAsync_ShouldDeleteMatter()
    {
        // Arrange
        var expectedResponse = TestDataFactory.CreateApiResponse(new { success = true });
        SetupMockResponse(expectedResponse);

        // Act
        await _client.DeleteAsync(123);

        // Assert
        VerifyHttpRequest("DELETE", "matters/123", Times.Once);
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