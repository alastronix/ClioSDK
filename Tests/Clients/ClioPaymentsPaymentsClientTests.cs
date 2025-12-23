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

public class ClioPaymentsPaymentsClientTests : TestBase
{
    private readonly ClioPaymentsPaymentsClient _client;

    public ClioPaymentsPaymentsClientTests()
    {
        _client = new ClioPaymentsPaymentsClient(HttpClient);
    }

    #region GetAsync Tests
    [Fact]
    public async Task GetAsync_ShouldReturnClioPaymentsPayments_WhenCalled()
    {
        // Arrange
        var expectedItems = CreateTestClioPaymentsPaymentsList(3);
        
        // Act
        var result = await _client.GetAsync();
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetAsync_WithQueryOptions_ShouldReturnFilteredClioPaymentsPayments()
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
    public async Task GetByIdAsync_ShouldReturnClioPaymentsPayments_WhenExists()
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
    public async Task PostAsync_ShouldCreateClioPaymentsPayments_WhenValid()
    {
        // Arrange
        var newClioPaymentsPayments = CreateTestClioPaymentsPayments();
        
        // Act
        var result = await _client.PostAsync(newClioPaymentsPayments);
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Should().NotBeNull();
    }
    #endregion

    #region UpdateAsync Tests
    [Fact]
    public async Task UpdateAsync_ShouldUpdateClioPaymentsPayments_WhenExists()
    {
        // Arrange
        var testId = 1;
        var updateData = CreateTestClioPaymentsPayments();
        
        // Act
        var result = await _client.UpdateAsync(testId, updateData);
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Id.Should().Be(testId);
    }
    #endregion

    #region DeleteAsync Tests
    [Fact]
    public async Task DeleteAsync_ShouldDeleteClioPaymentsPayments_WhenExists()
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
    private ClioPaymentsPayments CreateTestClioPaymentsPayments()
    {
        return new ClioPaymentsPayments
        {
            // Set test properties here
            Id = 1,
            Name = "Test ClioPaymentsPayments",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }

    private List<ClioPaymentsPayments> CreateTestClioPaymentsPaymentsList(int count)
    {
        var list = new List<ClioPaymentsPayments>();
        for (int i = 1; i <= count; i++)
        {
            list.Add(CreateTestClioPaymentsPayments());
        }
        return list;
    }
    #endregion
}