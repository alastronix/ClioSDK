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

public class BankAccountsClientTests : TestBase
{
    private readonly BankAccountsClient _client;

    public BankAccountsTests()
    {
        _client = new BankAccountsClient(HttpClient);
    }

    #region GetAsync Tests
    [Fact]
    public async System.Threading.Tasks.Task GetAsync_ShouldReturnBankAccount_WhenCalled()
    {
        // Arrange
        var expectedItems = CreateTestBankAccountList(3);
        var expectedResponse = TestDataFactory.CreatePaginatedResponse(expectedItems);
        
        SetupMockResponse(expectedResponse);

        // Act
        var result = await _client.GetAsync();

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().HaveCount(3);
        VerifyHttpRequest("GET", "bankaccount", Times.Once);
    }

    [Fact]
    public async System.Threading.Tasks.Task GetAsync_WithId_ShouldReturnSingleBankAccount()
    {
        // Arrange
        var expectedItem = CreateTestBankAccount(123);
        var expectedResponse = TestDataFactory.CreateApiResponse(expectedItem);
        
        SetupMockResponse(expectedResponse);

        // Act
        var result = await _client.GetAsync(123);

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().NotBeNull();
        VerifyHttpRequest("GET", "bankaccount/123", Times.Once);
    }

    [Fact]
    public async System.Threading.Tasks.Task GetAsync_ShouldHandleErrorResponse()
    {
        // Arrange
        SetupMockErrorResponse(HttpStatusCode.NotFound, "BankAccount not found");

        // Act & Assert
        await Assert.ThrowsAsync<HttpRequestException>(() => _client.GetAsync(999));
        VerifyHttpRequest("GET", "bankaccount/999", Times.Once);
    }
    #endregion

    private List<BankAccount> CreateTestBankAccountList(int count)
    {
        var list = new List<BankAccount>();
        for (int i = 1; i <= count; i++)
        {
            list.Add(CreateTestBankAccount(i * 100));
        }
        return list;
    }

    private BankAccount CreateTestBankAccount(int id)
    {
        return new BankAccount
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