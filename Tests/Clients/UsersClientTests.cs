using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;
using ClioSDK.Clients;
using ClioSDK.Models;
using ClioSDK.Tests.TestHelpers;
using FluentAssertions;
using Xunit;
using ClioSDK.Models.Requests;

namespace ClioSDK.Tests.Clients;

public class UsersClientTests : TestBase
{
    private readonly UsersClient _client;

    public UsersClientTests()
    {
        _client = new UsersClient(HttpClient);
    }

    #region GetAsync Tests
    [Fact]
    public async System.Threading.Tasks.Task GetAsync_ShouldReturnUsers_WhenCalled()
    {
        // Arrange
        var expectedUsers = TestDataFactory.CreateList(3, TestDataFactory.CreateUser);
        var expectedResponse = TestDataFactory.CreatePaginatedResponse(expectedUsers);
        
        SetupMockResponse(expectedResponse);

        // Act
        var result = await _client.GetAsync();

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().HaveCount(3);
        result.Data.Should().BeEquivalentTo(expectedUsers);
        VerifyHttpRequest("GET", "users", Times.Once);
    }

    [Fact]
    public async System.Threading.Tasks.Task GetAsync_WithId_ShouldReturnSingleUser()
    {
        // Arrange
        var expectedUser = TestDataFactory.CreateUser(123);
        var expectedResponse = TestDataFactory.CreateApiResponse(expectedUser);
        
        SetupMockResponse(expectedResponse);

        // Act
        var result = await _client.GetAsync(123);

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().BeEquivalentTo(expectedUser);
        VerifyHttpRequest("GET", "users/123", Times.Once);
    }

    [Fact]
    public async System.Threading.Tasks.Task GetAsync_ShouldHandleErrorResponse()
    {
        // Arrange
        SetupMockErrorResponse(HttpStatusCode.NotFound, "User not found");

        // Act & Assert
        await Assert.ThrowsAsync<HttpRequestException>(() => _client.GetAsync(999));
        VerifyHttpRequest("GET", "users/999", Times.Once);
    }
    #endregion

    #region Integration Tests
    [Fact]
    public async System.Threading.Tasks.Task UserRetrieval_ShouldWorkConsistently()
    {
        // Arrange
        var users = TestDataFactory.CreateList(5, TestDataFactory.CreateUser);
        var singleUser = TestDataFactory.CreateUser(123);

        // Setup responses
        SetupMockResponse(TestDataFactory.CreatePaginatedResponse(users));
        SetupMockResponse(TestDataFactory.CreateApiResponse(singleUser));

        // Act
        var allUsers = await _client.GetAsync();
        var specificUser = await _client.GetAsync(123);

        // Assert
        allUsers.Should().NotBeNull();
        allUsers.Data.Should().HaveCount(5);
        specificUser.Should().NotBeNull();
        specificUser.Data.Id.Should().Be(123);

        // Verify user data consistency
        allUsers.Data.Should().AllSatisfy(u => 
        {
            u.Id.Should().BeGreaterThan(0);
            u.Email.Should().Contain("@");
            u.Name.Should().NotBeNullOrEmpty();
        });
    }

    [Fact]
    public async System.Threading.Tasks.Task UserPermissions_ShouldHandleAccessControl()
    {
        // Arrange
        SetupMockErrorResponse(HttpStatusCode.Forbidden, "Access denied");

        // Act & Assert
        await Assert.ThrowsAsync<HttpRequestException>(() => _client.GetAsync());
        VerifyHttpRequest("GET", "users", Times.Once);
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