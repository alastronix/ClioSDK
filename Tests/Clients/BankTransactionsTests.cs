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

public class BankTransactionsClientTests : TestBase
{
    private readonly BankTransactionsClient _client;

    public BankTransactionsTests()
    {
        _client = new BankTransactionsClient(HttpClient);
    }

    #region GetAsync Tests
    [Fact]
    public async System.Threading.Tasks.Task GetAsync_ShouldReturnBankTransaction_WhenCalled()
    {
        // Arrange
        var expectedItems = CreateTestBankTransactionList(3);
        var expectedResponse = TestDataFactory.CreatePaginatedResponse(expectedItems);
        
        SetupMockResponse(expectedResponse);

        // Act
        var result = await _client.GetAsync();

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().HaveCount(3);
        VerifyHttpRequest("GET", "banktransaction", Times.Once);
    }

    [Fact]
    public async System.Threading.Tasks.Task GetAsync_WithId_ShouldReturnSingleBankTransaction()
    {
        // Arrange
        var expectedItem = CreateTestBankTransaction(123);
        var expectedResponse = TestDataFactory.CreateApiResponse(expectedItem);
        
        SetupMockResponse(expectedResponse);

        // Act
        var result = await _client.GetAsync(123);

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().NotBeNull();
        VerifyHttpRequest("GET", "banktransaction/123", Times.Once);
    }

    [Fact]
    public async System.Threading.Tasks.Task GetAsync_ShouldHandleErrorResponse()
    {
        // Arrange
        SetupMockErrorResponse(HttpStatusCode.NotFound, "BankTransaction not found");

        // Act & Assert
        await Assert.ThrowsAsync<HttpRequestException>(() => _client.GetAsync(999));
        VerifyHttpRequest("GET", "banktransaction/999", Times.Once);
    }
    #endregion

    private List<BankTransaction> CreateTestBankTransactionList(int count)
    {
        var list = new List<BankTransaction>();
        for (int i = 1; i <= count; i++)
        {
            list.Add(CreateTestBankTransaction(i * 100));
        }
        return list;
    }

    private BankTransaction CreateTestBankTransaction(int id)
    {
        return new BankTransaction
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