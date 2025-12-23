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

public class PhoneNumbersClientTests : TestBase
{
    private readonly PhoneNumbersClient _client;

    public PhoneNumbersClientTests()
    {
        _client = new PhoneNumbersClient(HttpClient);
    }

    #region GetAsync Tests
    [Fact]
    public async Task GetAsync_ShouldReturnPhoneNumbers_WhenCalled()
    {
        // Arrange
        var expectedItems = CreateTestPhoneNumbersList(3);
        
        // Act
        var result = await _client.GetAsync();
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetAsync_WithQueryOptions_ShouldReturnFilteredPhoneNumbers()
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
    public async Task GetByIdAsync_ShouldReturnPhoneNumbers_WhenExists()
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
    public async Task PostAsync_ShouldCreatePhoneNumbers_WhenValid()
    {
        // Arrange
        var newPhoneNumbers = CreateTestPhoneNumbers();
        
        // Act
        var result = await _client.PostAsync(newPhoneNumbers);
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Should().NotBeNull();
    }
    #endregion

    #region UpdateAsync Tests
    [Fact]
    public async Task UpdateAsync_ShouldUpdatePhoneNumbers_WhenExists()
    {
        // Arrange
        var testId = 1;
        var updateData = CreateTestPhoneNumbers();
        
        // Act
        var result = await _client.UpdateAsync(testId, updateData);
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Id.Should().Be(testId);
    }
    #endregion

    #region DeleteAsync Tests
    [Fact]
    public async Task DeleteAsync_ShouldDeletePhoneNumbers_WhenExists()
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
    private PhoneNumbers CreateTestPhoneNumbers()
    {
        return new PhoneNumbers
        {
            // Set test properties here
            Id = 1,
            Name = "Test PhoneNumbers",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }

    private List<PhoneNumbers> CreateTestPhoneNumbersList(int count)
    {
        var list = new List<PhoneNumbers>();
        for (int i = 1; i <= count; i++)
        {
            list.Add(CreateTestPhoneNumbers());
        }
        return list;
    }
    #endregion
}