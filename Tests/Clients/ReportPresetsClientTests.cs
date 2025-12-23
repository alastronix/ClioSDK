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

public class ReportPresetsClientTests : TestBase
{
    private readonly ReportPresetsClient _client;

    public ReportPresetsClientTests()
    {
        _client = new ReportPresetsClient(HttpClient);
    }

    #region GetAsync Tests
    [Fact]
    public async Task GetAsync_ShouldReturnReportPresets_WhenCalled()
    {
        // Arrange
        var expectedItems = CreateTestReportPresetsList(3);
        
        // Act
        var result = await _client.GetAsync();
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetAsync_WithQueryOptions_ShouldReturnFilteredReportPresets()
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
    public async Task GetByIdAsync_ShouldReturnReportPresets_WhenExists()
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
    public async Task PostAsync_ShouldCreateReportPresets_WhenValid()
    {
        // Arrange
        var newReportPresets = CreateTestReportPresets();
        
        // Act
        var result = await _client.PostAsync(newReportPresets);
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Should().NotBeNull();
    }
    #endregion

    #region UpdateAsync Tests
    [Fact]
    public async Task UpdateAsync_ShouldUpdateReportPresets_WhenExists()
    {
        // Arrange
        var testId = 1;
        var updateData = CreateTestReportPresets();
        
        // Act
        var result = await _client.UpdateAsync(testId, updateData);
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Id.Should().Be(testId);
    }
    #endregion

    #region DeleteAsync Tests
    [Fact]
    public async Task DeleteAsync_ShouldDeleteReportPresets_WhenExists()
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
    private ReportPresets CreateTestReportPresets()
    {
        return new ReportPresets
        {
            // Set test properties here
            Id = 1,
            Name = "Test ReportPresets",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }

    private List<ReportPresets> CreateTestReportPresetsList(int count)
    {
        var list = new List<ReportPresets>();
        for (int i = 1; i <= count; i++)
        {
            list.Add(CreateTestReportPresets());
        }
        return list;
    }
    #endregion
}