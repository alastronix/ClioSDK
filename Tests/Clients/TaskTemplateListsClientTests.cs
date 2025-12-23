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

public class TaskTemplateListsClientTests : TestBase
{
    private readonly TaskTemplateListsClient _client;

    public TaskTemplateListsClientTests()
    {
        _client = new TaskTemplateListsClient(HttpClient);
    }

    #region GetAsync Tests
    [Fact]
    public async Task GetAsync_ShouldReturnTaskTemplateLists_WhenCalled()
    {
        // Arrange
        var expectedItems = CreateTestTaskTemplateListsList(3);
        
        // Act
        var result = await _client.GetAsync();
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetAsync_WithQueryOptions_ShouldReturnFilteredTaskTemplateLists()
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
    public async Task GetByIdAsync_ShouldReturnTaskTemplateLists_WhenExists()
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
    public async Task PostAsync_ShouldCreateTaskTemplateLists_WhenValid()
    {
        // Arrange
        var newTaskTemplateLists = CreateTestTaskTemplateLists();
        
        // Act
        var result = await _client.PostAsync(newTaskTemplateLists);
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Should().NotBeNull();
    }
    #endregion

    #region UpdateAsync Tests
    [Fact]
    public async Task UpdateAsync_ShouldUpdateTaskTemplateLists_WhenExists()
    {
        // Arrange
        var testId = 1;
        var updateData = CreateTestTaskTemplateLists();
        
        // Act
        var result = await _client.UpdateAsync(testId, updateData);
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Id.Should().Be(testId);
    }
    #endregion

    #region DeleteAsync Tests
    [Fact]
    public async Task DeleteAsync_ShouldDeleteTaskTemplateLists_WhenExists()
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
    private TaskTemplateLists CreateTestTaskTemplateLists()
    {
        return new TaskTemplateLists
        {
            // Set test properties here
            Id = 1,
            Name = "Test TaskTemplateLists",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }

    private List<TaskTemplateLists> CreateTestTaskTemplateListsList(int count)
    {
        var list = new List<TaskTemplateLists>();
        for (int i = 1; i <= count; i++)
        {
            list.Add(CreateTestTaskTemplateLists());
        }
        return list;
    }
    #endregion
}