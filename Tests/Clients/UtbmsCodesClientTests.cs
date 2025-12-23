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

public class UtbmsCodesClientTests : TestBase
{
    private readonly UtbmsCodesClient _client;

    public UtbmsCodesClientTests()
    {
        _client = new UtbmsCodesClient(HttpClient);
    }

    #region GetAsync Tests
    [Fact]
    public async Task GetAsync_ShouldReturnUtbmsCodes_WhenCalled()
    {
        // Arrange
        var expectedItems = CreateTestUtbmsCodesList(3);
        
        // Act
        var result = await _client.GetAsync();
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetAsync_WithQueryOptions_ShouldReturnFilteredUtbmsCodes()
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
    public async Task GetByIdAsync_ShouldReturnUtbmsCodes_WhenExists()
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
    public async Task PostAsync_ShouldCreateUtbmsCodes_WhenValid()
    {
        // Arrange
        var newUtbmsCodes = CreateTestUtbmsCodes();
        
        // Act
        var result = await _client.PostAsync(newUtbmsCodes);
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Should().NotBeNull();
    }
    #endregion

    #region UpdateAsync Tests
    [Fact]
    public async Task UpdateAsync_ShouldUpdateUtbmsCodes_WhenExists()
    {
        // Arrange
        var testId = 1;
        var updateData = CreateTestUtbmsCodes();
        
        // Act
        var result = await _client.UpdateAsync(testId, updateData);
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Id.Should().Be(testId);
    }
    #endregion

    #region DeleteAsync Tests
    [Fact]
    public async Task DeleteAsync_ShouldDeleteUtbmsCodes_WhenExists()
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
    private UtbmsCodes CreateTestUtbmsCodes()
    {
        return new UtbmsCodes
        {
            // Set test properties here
            Id = 1,
            Name = "Test UtbmsCodes",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }

    private List<UtbmsCodes> CreateTestUtbmsCodesList(int count)
    {
        var list = new List<UtbmsCodes>();
        for (int i = 1; i <= count; i++)
        {
            list.Add(CreateTestUtbmsCodes());
        }
        return list;
    }
    #endregion
}