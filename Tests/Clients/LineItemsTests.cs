using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;
using ClioSDK.Clients;
using ClioSDK.Models;
using ClioSDK.Tests.TestHelpers;
using FluentAssertions;
using Xunit;
using ClioSDK.Models.Requests;

namespace ClioSDK.Tests.Clients;

public class LineItemsClientTests : TestBase
{
    private readonly LineItemsClient _client;

    public LineItemsTests()
    {
        _client = new LineItemsClient(HttpClient);
    }

    #region GetAsync Tests
    [Fact]
    public async System.Threading.Tasks.Task GetAsync_ShouldReturnLineItem_WhenCalled()
    {
        // Arrange
        var expectedItems = CreateTestLineItemList(3);
        var expectedResponse = TestDataFactory.CreatePaginatedResponse(expectedItems);
        
        SetupMockResponse(expectedResponse);

        // Act
        var result = await _client.GetAsync();

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().HaveCount(3);
        VerifyHttpRequest("GET", "lineitem", Times.Once);
    }

    [Fact]
    public async System.Threading.Tasks.Task GetAsync_WithId_ShouldReturnSingleLineItem()
    {
        // Arrange
        var expectedItem = CreateTestLineItem(123);
        var expectedResponse = TestDataFactory.CreateApiResponse(expectedItem);
        
        SetupMockResponse(expectedResponse);

        // Act
        var result = await _client.GetAsync(123);

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().NotBeNull();
        VerifyHttpRequest("GET", "lineitem/123", Times.Once);
    }

    [Fact]
    public async System.Threading.Tasks.Task GetAsync_ShouldHandleErrorResponse()
    {
        // Arrange
        SetupMockErrorResponse(HttpStatusCode.NotFound, "LineItem not found");

        // Act & Assert
        await Assert.ThrowsAsync<HttpRequestException>(() => _client.GetAsync(999));
        VerifyHttpRequest("GET", "lineitem/999", Times.Once);
    }
    #endregion

    private List<LineItem> CreateTestLineItemList(int count)
    {
        var list = new List<LineItem>();
        for (int i = 1; i <= count; i++)
        {
            list.Add(CreateTestLineItem(i * 100));
        }
        return list;
    }

    private LineItem CreateTestLineItem(int id)
    {
        return new LineItem
        {
            Id = id,
            CreatedAt = DateTime.UtcNow.AddDays(-id),
            UpdatedAt = DateTime.UtcNow.AddHours(-id)
        };
    }

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