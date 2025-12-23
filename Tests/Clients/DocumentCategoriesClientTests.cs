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

public class DocumentCategoriesClientTests : TestBase
{
    private readonly DocumentCategoriesClient _client;

    public DocumentCategoriesClientTests()
    {
        _client = new DocumentCategoriesClient(HttpClient);
    }

    #region GetAsync Tests
    [Fact]
    public async Task GetAsync_ShouldReturnDocumentCategories_WhenCalled()
    {
        // Arrange
        var expectedItems = CreateTestDocumentCategoriesList(3);
        
        // Act
        var result = await _client.GetAsync();
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetAsync_WithQueryOptions_ShouldReturnFilteredDocumentCategories()
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
    public async Task GetByIdAsync_ShouldReturnDocumentCategories_WhenExists()
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
    public async Task PostAsync_ShouldCreateDocumentCategories_WhenValid()
    {
        // Arrange
        var newDocumentCategories = CreateTestDocumentCategories();
        
        // Act
        var result = await _client.PostAsync(newDocumentCategories);
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Should().NotBeNull();
    }
    #endregion

    #region UpdateAsync Tests
    [Fact]
    public async Task UpdateAsync_ShouldUpdateDocumentCategories_WhenExists()
    {
        // Arrange
        var testId = 1;
        var updateData = CreateTestDocumentCategories();
        
        // Act
        var result = await _client.UpdateAsync(testId, updateData);
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Id.Should().Be(testId);
    }
    #endregion

    #region DeleteAsync Tests
    [Fact]
    public async Task DeleteAsync_ShouldDeleteDocumentCategories_WhenExists()
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
    private DocumentCategories CreateTestDocumentCategories()
    {
        return new DocumentCategories
        {
            // Set test properties here
            Id = 1,
            Name = "Test DocumentCategories",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }

    private List<DocumentCategories> CreateTestDocumentCategoriesList(int count)
    {
        var list = new List<DocumentCategories>();
        for (int i = 1; i <= count; i++)
        {
            list.Add(CreateTestDocumentCategories());
        }
        return list;
    }
    #endregion
}