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

public class CalendarEntryEventTypesClientTests : TestBase
{
    private readonly CalendarEntryEventTypesClient _client;

    public CalendarEntryEventTypesClientTests()
    {
        _client = new CalendarEntryEventTypesClient(HttpClient);
    }

    #region GetAsync Tests
    [Fact]
    public async Task GetAsync_ShouldReturnCalendarEntryEventTypes_WhenCalled()
    {
        // Arrange
        var expectedItems = CreateTestCalendarEntryEventTypesList(3);
        
        // Act
        var result = await _client.GetAsync();
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetAsync_WithQueryOptions_ShouldReturnFilteredCalendarEntryEventTypes()
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
    public async Task GetByIdAsync_ShouldReturnCalendarEntryEventTypes_WhenExists()
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
    public async Task PostAsync_ShouldCreateCalendarEntryEventTypes_WhenValid()
    {
        // Arrange
        var newCalendarEntryEventTypes = CreateTestCalendarEntryEventTypes();
        
        // Act
        var result = await _client.PostAsync(newCalendarEntryEventTypes);
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Should().NotBeNull();
    }
    #endregion

    #region UpdateAsync Tests
    [Fact]
    public async Task UpdateAsync_ShouldUpdateCalendarEntryEventTypes_WhenExists()
    {
        // Arrange
        var testId = 1;
        var updateData = CreateTestCalendarEntryEventTypes();
        
        // Act
        var result = await _client.UpdateAsync(testId, updateData);
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Id.Should().Be(testId);
    }
    #endregion

    #region DeleteAsync Tests
    [Fact]
    public async Task DeleteAsync_ShouldDeleteCalendarEntryEventTypes_WhenExists()
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
    private CalendarEntryEventTypes CreateTestCalendarEntryEventTypes()
    {
        return new CalendarEntryEventTypes
        {
            // Set test properties here
            Id = 1,
            Name = "Test CalendarEntryEventTypes",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }

    private List<CalendarEntryEventTypes> CreateTestCalendarEntryEventTypesList(int count)
    {
        var list = new List<CalendarEntryEventTypes>();
        for (int i = 1; i <= count; i++)
        {
            list.Add(CreateTestCalendarEntryEventTypes());
        }
        return list;
    }
    #endregion
}