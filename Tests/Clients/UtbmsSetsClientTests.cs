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

public class UtbmsSetsClientTests : TestBase
{
    private readonly UtbmsSetsClient _client;

    public UtbmsSetsClientTests()
    {
        _client = new UtbmsSetsClient(HttpClient);
    }

    #region GetAsync Tests
    [Fact]
    public async Task GetAsync_ShouldReturnUtbmsSets_WhenCalled()
    {
        // Arrange
        var expectedItems = CreateTestUtbmsSetsList(3);
        
        // Act
        var result = await _client.GetAsync();
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetAsync_WithQueryOptions_ShouldReturnFilteredUtbmsSets()
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
    public async Task GetByIdAsync_ShouldReturnUtbmsSets_WhenExists()
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
    public async Task PostAsync_ShouldCreateUtbmsSets_WhenValid()
    {
        // Arrange
        var newUtbmsSets = CreateTestUtbmsSets();
        
        // Act
        var result = await _client.PostAsync(newUtbmsSets);
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Should().NotBeNull();
    }
    #endregion

    #region UpdateAsync Tests
    [Fact]
    public async Task UpdateAsync_ShouldUpdateUtbmsSets_WhenExists()
    {
        // Arrange
        var testId = 1;
        var updateData = CreateTestUtbmsSets();
        
        // Act
        var result = await _client.UpdateAsync(testId, updateData);
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Id.Should().Be(testId);
    }
    #endregion

    #region DeleteAsync Tests
    [Fact]
    public async Task DeleteAsync_ShouldDeleteUtbmsSets_WhenExists()
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
    private UtbmsSets CreateTestUtbmsSets()
    {
        return new UtbmsSets
        {
            // Set test properties here
            Id = 1,
            Name = "Test UtbmsSets",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }

    private List<UtbmsSets> CreateTestUtbmsSetsList(int count)
    {
        var list = new List<UtbmsSets>();
        for (int i = 1; i <= count; i++)
        {
            list.Add(CreateTestUtbmsSets());
        }
        return list;
    }
    #endregion
}