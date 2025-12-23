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

public class ContactsClientTests : TestBase
{
    private readonly ContactsClient _client;

    public ContactsClientTests()
    {
        _client = new ContactsClient(HttpClient);
    }

    #region GetAsync Tests
    [Fact]
    public async System.Threading.Tasks.Task GetAsync_ShouldReturnContacts_WhenCalled()
    {
        // Arrange
        var expectedContacts = TestDataFactory.CreateList(3, TestDataFactory.CreateContact);
        var expectedResponse = TestDataFactory.CreatePaginatedResponse(expectedContacts);
        
        SetupMockResponse(expectedResponse);

        // Act
        var result = await _client.GetAsync();

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().HaveCount(3);
        result.Data.Should().BeEquivalentTo(expectedContacts);
        VerifyHttpRequest("GET", "contacts", Times.Once);
    }

    [Fact]
    public async System.Threading.Tasks.Task GetAsync_WithId_ShouldReturnSingleContact()
    {
        // Arrange
        var expectedContact = TestDataFactory.CreateContact(123);
        var expectedResponse = TestDataFactory.CreateApiResponse(expectedContact);
        
        SetupMockResponse(expectedResponse);

        // Act
        var result = await _client.GetAsync(123);

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().BeEquivalentTo(expectedContact);
        VerifyHttpRequest("GET", "contacts/123", Times.Once);
    }

    [Fact]
    public async System.Threading.Tasks.Task GetAsync_ShouldHandleErrorResponse()
    {
        // Arrange
        SetupMockErrorResponse(HttpStatusCode.NotFound, "Contact not found");

        // Act & Assert
        await Assert.ThrowsAsync<HttpRequestException>(() => _client.GetAsync(999));
        VerifyHttpRequest("GET", "contacts/999", Times.Once);
    }
    #endregion

    #region CreateAsync Tests
    [Fact]
    public async System.Threading.Tasks.Task CreateAsync_ShouldCreateContact()
    {
        // Arrange
        var request = TestDataFactory.CreateContactRequest();
        var expectedContact = TestDataFactory.CreateContact(123);
        var expectedResponse = TestDataFactory.CreateApiResponse(expectedContact);

        SetupMockResponse(expectedResponse);

        // Act
        var result = await _client.CreateAsync(request);

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().BeEquivalentTo(expectedContact);
        VerifyHttpRequest("POST", "contacts", Times.Once);
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
    public async System.Threading.Tasks.Task UpdateAsync_ShouldUpdateContact()
    {
        // Arrange
        var request = TestDataFactory.CreateContactRequest();
        var expectedContact = TestDataFactory.CreateContact(123);
        var expectedResponse = TestDataFactory.CreateApiResponse(expectedContact);

        SetupMockResponse(expectedResponse);

        // Act
        var result = await _client.UpdateAsync(123, request);

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().BeEquivalentTo(expectedContact);
        VerifyHttpRequest("PUT", "contacts/123", Times.Once);
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
    public async System.Threading.Tasks.Task DeleteAsync_ShouldDeleteContact()
    {
        // Arrange
        var expectedResponse = TestDataFactory.CreateApiResponse(new { success = true });
        SetupMockResponse(expectedResponse);

        // Act
        await _client.DeleteAsync(123);

        // Assert
        VerifyHttpRequest("DELETE", "contacts/123", Times.Once);
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