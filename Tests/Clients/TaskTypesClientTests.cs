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

public class TaskTypesClientTests : TestBase
{
    private readonly TaskTypesClient _client;

    public TaskTypesClientTests()
    {
        _client = new TaskTypesClient(HttpClient);
    }

    #region GetAsync Tests
    [Fact]
    public async Task GetAsync_ShouldReturnTaskTypes_WhenCalled()
    {
        // Arrange
        var expectedItems = CreateTestTaskTypesList(3);
        
        // Act
        var result = await _client.GetAsync();
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetAsync_WithQueryOptions_ShouldReturnFilteredTaskTypes()
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
    public async Task GetByIdAsync_ShouldReturnTaskTypes_WhenExists()
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
    public async Task PostAsync_ShouldCreateTaskTypes_WhenValid()
    {
        // Arrange
        var newTaskTypes = CreateTestTaskTypes();
        
        // Act
        var result = await _client.PostAsync(newTaskTypes);
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Should().NotBeNull();
    }
    #endregion

    #region UpdateAsync Tests
    [Fact]
    public async Task UpdateAsync_ShouldUpdateTaskTypes_WhenExists()
    {
        // Arrange
        var testId = 1;
        var updateData = CreateTestTaskTypes();
        
        // Act
        var result = await _client.UpdateAsync(testId, updateData);
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Id.Should().Be(testId);
    }
    #endregion

    #region DeleteAsync Tests
    [Fact]
    public async Task DeleteAsync_ShouldDeleteTaskTypes_WhenExists()
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
    private TaskTypes CreateTestTaskTypes()
    {
        return new TaskTypes
        {
            // Set test properties here
            Id = 1,
            Name = "Test TaskTypes",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }

    private List<TaskTypes> CreateTestTaskTypesList(int count)
    {
        var list = new List<TaskTypes>();
        for (int i = 1; i <= count; i++)
        {
            list.Add(CreateTestTaskTypes());
        }
        return list;
    }
    #endregion
}