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

public class InterestChargesClientTests : TestBase
{
    private readonly InterestChargesClient _client;

    public InterestChargesClientTests()
    {
        _client = new InterestChargesClient(HttpClient);
    }

    #region GetAsync Tests
    [Fact]
    public async Task GetAsync_ShouldReturnInterestCharges_WhenCalled()
    {
        // Arrange
        var expectedItems = CreateTestInterestChargesList(3);
        
        // Act
        var result = await _client.GetAsync();
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetAsync_WithQueryOptions_ShouldReturnFilteredInterestCharges()
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
    public async Task GetByIdAsync_ShouldReturnInterestCharges_WhenExists()
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
    public async Task PostAsync_ShouldCreateInterestCharges_WhenValid()
    {
        // Arrange
        var newInterestCharges = CreateTestInterestCharges();
        
        // Act
        var result = await _client.PostAsync(newInterestCharges);
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Should().NotBeNull();
    }
    #endregion

    #region UpdateAsync Tests
    [Fact]
    public async Task UpdateAsync_ShouldUpdateInterestCharges_WhenExists()
    {
        // Arrange
        var testId = 1;
        var updateData = CreateTestInterestCharges();
        
        // Act
        var result = await _client.UpdateAsync(testId, updateData);
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Id.Should().Be(testId);
    }
    #endregion

    #region DeleteAsync Tests
    [Fact]
    public async Task DeleteAsync_ShouldDeleteInterestCharges_WhenExists()
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
    private InterestCharges CreateTestInterestCharges()
    {
        return new InterestCharges
        {
            // Set test properties here
            Id = 1,
            Name = "Test InterestCharges",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }

    private List<InterestCharges> CreateTestInterestChargesList(int count)
    {
        var list = new List<InterestCharges>();
        for (int i = 1; i <= count; i++)
        {
            list.Add(CreateTestInterestCharges());
        }
        return list;
    }
    #endregion
}