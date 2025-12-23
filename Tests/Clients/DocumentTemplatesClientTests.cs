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

public class DocumentTemplatesClientTests : TestBase
{
    private readonly DocumentTemplatesClient _client;

    public DocumentTemplatesClientTests()
    {
        _client = new DocumentTemplatesClient(HttpClient);
    }

    #region GetAsync Tests
    [Fact]
    public async Task GetAsync_ShouldReturnDocumentTemplates_WhenCalled()
    {
        // Arrange
        var expectedItems = CreateTestDocumentTemplatesList(3);
        
        // Act
        var result = await _client.GetAsync();
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Should().NotBeEmpty();
    }

    [Fact]
    public async Task GetAsync_WithQueryOptions_ShouldReturnFilteredDocumentTemplates()
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
    public async Task GetByIdAsync_ShouldReturnDocumentTemplates_WhenExists()
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
    public async Task PostAsync_ShouldCreateDocumentTemplates_WhenValid()
    {
        // Arrange
        var newDocumentTemplates = CreateTestDocumentTemplates();
        
        // Act
        var result = await _client.PostAsync(newDocumentTemplates);
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Should().NotBeNull();
    }
    #endregion

    #region UpdateAsync Tests
    [Fact]
    public async Task UpdateAsync_ShouldUpdateDocumentTemplates_WhenExists()
    {
        // Arrange
        var testId = 1;
        var updateData = CreateTestDocumentTemplates();
        
        // Act
        var result = await _client.UpdateAsync(testId, updateData);
        
        // Assert
        result.Should().NotBeNull();
        result.Data.Id.Should().Be(testId);
    }
    #endregion

    #region DeleteAsync Tests
    [Fact]
    public async Task DeleteAsync_ShouldDeleteDocumentTemplates_WhenExists()
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
    private DocumentTemplates CreateTestDocumentTemplates()
    {
        return new DocumentTemplates
        {
            // Set test properties here
            Id = 1,
            Name = "Test DocumentTemplates",
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };
    }

    private List<DocumentTemplates> CreateTestDocumentTemplatesList(int count)
    {
        var list = new List<DocumentTemplates>();
        for (int i = 1; i <= count; i++)
        {
            list.Add(CreateTestDocumentTemplates());
        }
        return list;
    }
    #endregion
}