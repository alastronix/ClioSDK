using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;
using ClioSDK.Clients;
using ClioSDK.Models;
using FluentAssertions;
using Xunit;
using ClioSDK.Models.Requests;
using Microsoft.Extensions.Http;

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
    public async Task GetAsync_ShouldReturnUsers_WhenCalled()
    {
        // Arrange
        var expectedItems = CreateTestUsersList(3);
        
        // Act
        var result = await _client.GetAsync();
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetAsync_WithQueryOptions_ShouldReturnFilteredUsers()
    {
        // Arrange
        var queryOptions = new { field = "test" };
        
        // Act
        var result = await _client.GetAsync(queryOptions);
        
        // Assert
        result.Should().NotBeNull();
    }
    #endregion

    #region GetByIdAsync Tests
    [Fact]
    public async Task GetByIdAsync_ShouldReturnUsers_WhenExists()
    {
        // Arrange
        var testId = 1;
        
        // Act
        var result = await _client.GetByIdAsync(testId);
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Id.Should().Be(testId);
    }
    #endregion

    #region PostAsync Tests
    [Fact]
    public async Task PostAsync_ShouldCreateUsers_WhenValid()
    {
        // Arrange
        var newUsers = CreateTestUsers();
        
        // Act
        var result = await _client.PostAsync(newUsers);
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Should().NotBeNull();
    }
    #endregion

    #region UpdateAsync Tests
    [Fact]
    public async Task UpdateAsync_ShouldUpdateUsers_WhenExists()
    {
        // Arrange
        var testId = 1;
        var updateData = CreateTestUsers();
        
        // Act
        var result = await _client.UpdateAsync(testId, updateData);
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Id.Should().Be(testId);
    }
    #endregion

    #region DeleteAsync Tests
    [Fact]
    public async Task DeleteAsync_ShouldDeleteUsers_WhenExists()
    {
        // Arrange
        var testId = 1;
        
        // Act
        var result = await _client.DeleteAsync(testId);
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Should().BeTrue();
    }
    #endregion

    #region Helper Methods
    private Users CreateTestUsers()
    {
        return new Users
        {
            // Set test properties here
            Id = 1,
            Name = "Test Users",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }

    private List<Users> CreateTestUsersList(int count)
    {
        var list = new List<Users>();
        for (int i = 1; i <= count; i++)
        {
            list.Add(CreateTestUsers());
        }
        return list;
    }
    #endregion
}