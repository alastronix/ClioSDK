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

public class EmailAddressesClientTests : TestBase
{
    private readonly EmailAddressesClient _client;

    public EmailAddressesClientTests()
    {
        _client = new EmailAddressesClient(HttpClient);
    }

    #region GetAsync Tests
    [Fact]
    public async Task GetAsync_ShouldReturnEmailAddresses_WhenCalled()
    {
        // Arrange
        var expectedItems = CreateTestEmailAddressesList(3);
        
        // Act
        var result = await _client.GetAsync();
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetAsync_WithQueryOptions_ShouldReturnFilteredEmailAddresses()
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
    public async Task GetByIdAsync_ShouldReturnEmailAddresses_WhenExists()
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
    public async Task PostAsync_ShouldCreateEmailAddresses_WhenValid()
    {
        // Arrange
        var newEmailAddresses = CreateTestEmailAddresses();
        
        // Act
        var result = await _client.PostAsync(newEmailAddresses);
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Should().NotBeNull();
    }
    #endregion

    #region UpdateAsync Tests
    [Fact]
    public async Task UpdateAsync_ShouldUpdateEmailAddresses_WhenExists()
    {
        // Arrange
        var testId = 1;
        var updateData = CreateTestEmailAddresses();
        
        // Act
        var result = await _client.UpdateAsync(testId, updateData);
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Id.Should().Be(testId);
    }
    #endregion

    #region DeleteAsync Tests
    [Fact]
    public async Task DeleteAsync_ShouldDeleteEmailAddresses_WhenExists()
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
    private EmailAddresses CreateTestEmailAddresses()
    {
        return new EmailAddresses
        {
            // Set test properties here
            Id = 1,
            Name = "Test EmailAddresses",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }

    private List<EmailAddresses> CreateTestEmailAddressesList(int count)
    {
        var list = new List<EmailAddresses>();
        for (int i = 1; i <= count; i++)
        {
            list.Add(CreateTestEmailAddresses());
        }
        return list;
    }
    #endregion
}