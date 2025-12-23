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

public class ActivityDescriptionsClientTests : TestBase
{
    private readonly ActivityDescriptionsClient _client;

    public ActivityDescriptionsClientTests()
    {
        _client = new ActivityDescriptionsClient(HttpClient);
    }

    #region GetAsync Tests
    [Fact]
    public async Task GetAsync_ShouldReturnActivityDescriptions_WhenCalled()
    {
        // Arrange
        var expectedItems = CreateTestActivityDescriptionsList(3);
        
        // Act
        var result = await _client.GetAsync();
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetAsync_WithQueryOptions_ShouldReturnFilteredActivityDescriptions()
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
    public async Task GetByIdAsync_ShouldReturnActivityDescriptions_WhenExists()
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
    public async Task PostAsync_ShouldCreateActivityDescriptions_WhenValid()
    {
        // Arrange
        var newActivityDescriptions = CreateTestActivityDescriptions();
        
        // Act
        var result = await _client.PostAsync(newActivityDescriptions);
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Should().NotBeNull();
    }
    #endregion

    #region UpdateAsync Tests
    [Fact]
    public async Task UpdateAsync_ShouldUpdateActivityDescriptions_WhenExists()
    {
        // Arrange
        var testId = 1;
        var updateData = CreateTestActivityDescriptions();
        
        // Act
        var result = await _client.UpdateAsync(testId, updateData);
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Id.Should().Be(testId);
    }
    #endregion

    #region DeleteAsync Tests
    [Fact]
    public async Task DeleteAsync_ShouldDeleteActivityDescriptions_WhenExists()
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
    private ActivityDescriptions CreateTestActivityDescriptions()
    {
        return new ActivityDescriptions
        {
            // Set test properties here
            Id = 1,
            Name = "Test ActivityDescriptions",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }

    private List<ActivityDescriptions> CreateTestActivityDescriptionsList(int count)
    {
        var list = new List<ActivityDescriptions>();
        for (int i = 1; i <= count; i++)
        {
            list.Add(CreateTestActivityDescriptions());
        }
        return list;
    }
    #endregion
}