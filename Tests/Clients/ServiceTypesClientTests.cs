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

public class ServiceTypesClientTests : TestBase
{
    private readonly ServiceTypesClient _client;

    public ServiceTypesClientTests()
    {
        _client = new ServiceTypesClient(HttpClient);
    }

    #region GetAsync Tests
    [Fact]
    public async Task GetAsync_ShouldReturnServiceTypes_WhenCalled()
    {
        // Arrange
        var expectedItems = CreateTestServiceTypesList(3);
        
        // Act
        var result = await _client.GetAsync();
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetAsync_WithQueryOptions_ShouldReturnFilteredServiceTypes()
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
    public async Task GetByIdAsync_ShouldReturnServiceTypes_WhenExists()
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
    public async Task PostAsync_ShouldCreateServiceTypes_WhenValid()
    {
        // Arrange
        var newServiceTypes = CreateTestServiceTypes();
        
        // Act
        var result = await _client.PostAsync(newServiceTypes);
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Should().NotBeNull();
    }
    #endregion

    #region UpdateAsync Tests
    [Fact]
    public async Task UpdateAsync_ShouldUpdateServiceTypes_WhenExists()
    {
        // Arrange
        var testId = 1;
        var updateData = CreateTestServiceTypes();
        
        // Act
        var result = await _client.UpdateAsync(testId, updateData);
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Id.Should().Be(testId);
    }
    #endregion

    #region DeleteAsync Tests
    [Fact]
    public async Task DeleteAsync_ShouldDeleteServiceTypes_WhenExists()
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
    private ServiceTypes CreateTestServiceTypes()
    {
        return new ServiceTypes
        {
            // Set test properties here
            Id = 1,
            Name = "Test ServiceTypes",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }

    private List<ServiceTypes> CreateTestServiceTypesList(int count)
    {
        var list = new List<ServiceTypes>();
        for (int i = 1; i <= count; i++)
        {
            list.Add(CreateTestServiceTypes());
        }
        return list;
    }
    #endregion
}