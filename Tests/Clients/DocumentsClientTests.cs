using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;
using ClioSDK.Clients;
using ClioSDK.Models;
using ClioSDK.Models.Requests;
using ClioSDK.Tests.TestHelpers;
using FluentAssertions;
using Xunit;

namespace ClioSDK.Tests.Clients;

public class DocumentsClientTests : TestBase
{
    private readonly DocumentsClient _client;

    public DocumentsClientTests()
    {
        _client = new DocumentsClient(HttpClient);
    }

    #region GetAsync Tests
    [Fact]
    public async System.Threading.Tasks.Task GetAsync_ShouldReturnDocuments_WhenCalled()
    {
        // Arrange
        var expectedDocuments = TestDataFactory.CreateList(3, TestDataFactory.CreateDocument);
        var expectedResponse = TestDataFactory.CreatePaginatedResponse(expectedDocuments);
        
        SetupMockResponse(expectedResponse);

        // Act
        var result = await _client.GetAsync();

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().HaveCount(3);
        result.Data.Should().BeEquivalentTo(expectedDocuments);
        VerifyHttpRequest("GET", "documents", Times.Once);
    }

    [Fact]
    public async System.Threading.Tasks.Task GetAsync_WithId_ShouldReturnSingleDocument()
    {
        // Arrange
        var expectedDocument = TestDataFactory.CreateDocument(123);
        var expectedResponse = TestDataFactory.CreateApiResponse(expectedDocument);
        
        SetupMockResponse(expectedResponse);

        // Act
        var result = await _client.GetAsync(123);

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().BeEquivalentTo(expectedDocument);
        VerifyHttpRequest("GET", "documents/123", Times.Once);
    }

    [Fact]
    public async System.Threading.Tasks.Task GetAsync_ShouldHandleErrorResponse()
    {
        // Arrange
        SetupMockErrorResponse(HttpStatusCode.NotFound, "Document not found");

        // Act & Assert
        await Assert.ThrowsAsync<HttpRequestException>(() => _client.GetAsync(999));
        VerifyHttpRequest("GET", "documents/999", Times.Once);
    }
    #endregion

    #region CreateAsync Tests
    [Fact]
    public async System.Threading.Tasks.Task CreateAsync_ShouldCreateDocument()
    {
        // Arrange
        var request = TestDataFactory.CreateDocumentRequest();
        var expectedDocument = TestDataFactory.CreateDocument(123);
        var expectedResponse = TestDataFactory.CreateApiResponse(expectedDocument);

        SetupMockResponse(expectedResponse);

        // Act
        var result = await _client.CreateAsync(request);

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().BeEquivalentTo(expectedDocument);
        VerifyHttpRequest("POST", "documents", Times.Once);
    }

    [Fact]
    public async System.Threading.Tasks.Task CreateAsync_WithNullRequest_ShouldThrowArgumentNullException()
    {
        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => _client.CreateAsync(null!));
    }
    #endregion

    #region UpdateAsync Tests
    [Fact]
    public async System.Threading.Tasks.Task UpdateAsync_ShouldUpdateDocument()
    {
        // Arrange
        var request = TestDataFactory.CreateDocumentRequest();
        var expectedDocument = TestDataFactory.CreateDocument(123);
        var expectedResponse = TestDataFactory.CreateApiResponse(expectedDocument);

        SetupMockResponse(expectedResponse);

        // Act
        var result = await _client.UpdateAsync(123, request);

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().BeEquivalentTo(expectedDocument);
        VerifyHttpRequest("PUT", "documents/123", Times.Once);
    }

    [Fact]
    public async System.Threading.Tasks.Task UpdateAsync_WithNullRequest_ShouldThrowArgumentNullException()
    {
        // Act & Assert
        await Assert.ThrowsAsync<ArgumentNullException>(() => _client.UpdateAsync(123, null!));
    }
    #endregion

    #region DeleteAsync Tests
    [Fact]
    public async System.Threading.Tasks.Task DeleteAsync_ShouldDeleteDocument()
    {
        // Arrange
        var expectedResponse = TestDataFactory.CreateApiResponse(new { success = true });
        SetupMockResponse(expectedResponse);

        // Act
        await _client.DeleteAsync(123);

        // Assert
        VerifyHttpRequest("DELETE", "documents/123", Times.Once);
    }
    #endregion

    private void VerifyHttpRequest(string expectedMethod, string expectedPath, Times times)
    {
        MockHttpHandler
            .Protected()
            .Verify(
                "SendAsync",
                times,
                ItExpr.Is<HttpRequestMessage>(req => 
                    req.Method.ToString() == expectedMethod && 
                    req.RequestUri?.AbsolutePath.Contains(expectedPath) == true),
                ItExpr.IsAny<CancellationToken>());
    }
}