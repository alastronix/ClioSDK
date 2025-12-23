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

public class TaskTemplatesClientTests : TestBase
{
    private readonly TaskTemplatesClient _client;

    public TaskTemplatesClientTests()
    {
        _client = new TaskTemplatesClient(HttpClient);
    }

    #region GetAsync Tests
    [Fact]
    public async Task GetAsync_ShouldReturnTaskTemplates_WhenCalled()
    {
        // Arrange
        var expectedItems = CreateTestTaskTemplatesList(3);
        
        // Act
        var result = await _client.GetAsync();
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetAsync_WithQueryOptions_ShouldReturnFilteredTaskTemplates()
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
    public async Task GetByIdAsync_ShouldReturnTaskTemplates_WhenExists()
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
    public async Task PostAsync_ShouldCreateTaskTemplates_WhenValid()
    {
        // Arrange
        var newTaskTemplates = CreateTestTaskTemplates();
        
        // Act
        var result = await _client.PostAsync(newTaskTemplates);
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Should().NotBeNull();
    }
    #endregion

    #region UpdateAsync Tests
    [Fact]
    public async Task UpdateAsync_ShouldUpdateTaskTemplates_WhenExists()
    {
        // Arrange
        var testId = 1;
        var updateData = CreateTestTaskTemplates();
        
        // Act
        var result = await _client.UpdateAsync(testId, updateData);
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Id.Should().Be(testId);
    }
    #endregion

    #region DeleteAsync Tests
    [Fact]
    public async Task DeleteAsync_ShouldDeleteTaskTemplates_WhenExists()
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
    private TaskTemplates CreateTestTaskTemplates()
    {
        return new TaskTemplates
        {
            // Set test properties here
            Id = 1,
            Name = "Test TaskTemplates",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }

    private List<TaskTemplates> CreateTestTaskTemplatesList(int count)
    {
        var list = new List<TaskTemplates>();
        for (int i = 1; i <= count; i++)
        {
            list.Add(CreateTestTaskTemplates());
        }
        return list;
    }
    #endregion
}