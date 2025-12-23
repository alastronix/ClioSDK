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

public class PracticeAreasClientTests : TestBase
{
    private readonly PracticeAreasClient _client;

    public PracticeAreasTests()
    {
        _client = new PracticeAreasClient(HttpClient);
    }

    #region GetAsync Tests
    [Fact]
    public async System.Threading.Tasks.Task GetAsync_ShouldReturnPracticeArea_WhenCalled()
    {
        // Arrange
        var expectedItems = CreateTestPracticeAreaList(3);
        var expectedResponse = TestDataFactory.CreatePaginatedResponse(expectedItems);
        
        SetupMockResponse(expectedResponse);

        // Act
        var result = await _client.GetAsync();

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().HaveCount(3);
        VerifyHttpRequest("GET", "practicearea", Times.Once);
    }

    [Fact]
    public async System.Threading.Tasks.Task GetAsync_WithId_ShouldReturnSinglePracticeArea()
    {
        // Arrange
        var expectedItem = CreateTestPracticeArea(123);
        var expectedResponse = TestDataFactory.CreateApiResponse(expectedItem);
        
        SetupMockResponse(expectedResponse);

        // Act
        var result = await _client.GetAsync(123);

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().NotBeNull();
        VerifyHttpRequest("GET", "practicearea/123", Times.Once);
    }

    [Fact]
    public async System.Threading.Tasks.Task GetAsync_ShouldHandleErrorResponse()
    {
        // Arrange
        SetupMockErrorResponse(HttpStatusCode.NotFound, "PracticeArea not found");

        // Act & Assert
        await Assert.ThrowsAsync<HttpRequestException>(() => _client.GetAsync(999));
        VerifyHttpRequest("GET", "practicearea/999", Times.Once);
    }
    #endregion

    private List<PracticeArea> CreateTestPracticeAreaList(int count)
    {
        var list = new List<PracticeArea>();
        for (int i = 1; i <= count; i++)
        {
            list.Add(CreateTestPracticeArea(i * 100));
        }
        return list;
    }

    private PracticeArea CreateTestPracticeArea(int id)
    {
        return new PracticeArea
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