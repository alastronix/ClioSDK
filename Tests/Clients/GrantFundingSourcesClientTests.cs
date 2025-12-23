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

public class GrantFundingSourcesClientTests : TestBase
{
    private readonly GrantFundingSourcesClient _client;

    public GrantFundingSourcesClientTests()
    {
        _client = new GrantFundingSourcesClient(HttpClient);
    }

    #region GetAsync Tests
    [Fact]
    public async Task GetAsync_ShouldReturnGrantFundingSources_WhenCalled()
    {
        // Arrange
        var expectedItems = CreateTestGrantFundingSourcesList(3);
        
        // Act
        var result = await _client.GetAsync();
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetAsync_WithQueryOptions_ShouldReturnFilteredGrantFundingSources()
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
    public async Task GetByIdAsync_ShouldReturnGrantFundingSources_WhenExists()
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
    public async Task PostAsync_ShouldCreateGrantFundingSources_WhenValid()
    {
        // Arrange
        var newGrantFundingSources = CreateTestGrantFundingSources();
        
        // Act
        var result = await _client.PostAsync(newGrantFundingSources);
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Should().NotBeNull();
    }
    #endregion

    #region UpdateAsync Tests
    [Fact]
    public async Task UpdateAsync_ShouldUpdateGrantFundingSources_WhenExists()
    {
        // Arrange
        var testId = 1;
        var updateData = CreateTestGrantFundingSources();
        
        // Act
        var result = await _client.UpdateAsync(testId, updateData);
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Id.Should().Be(testId);
    }
    #endregion

    #region DeleteAsync Tests
    [Fact]
    public async Task DeleteAsync_ShouldDeleteGrantFundingSources_WhenExists()
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
    private GrantFundingSources CreateTestGrantFundingSources()
    {
        return new GrantFundingSources
        {
            // Set test properties here
            Id = 1,
            Name = "Test GrantFundingSources",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }

    private List<GrantFundingSources> CreateTestGrantFundingSourcesList(int count)
    {
        var list = new List<GrantFundingSources>();
        for (int i = 1; i <= count; i++)
        {
            list.Add(CreateTestGrantFundingSources());
        }
        return list;
    }
    #endregion
}