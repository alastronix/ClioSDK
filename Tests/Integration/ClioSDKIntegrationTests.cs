using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;
using ClioSDK.Clients;
using ClioSDK.Models;
using ClioSDK.Models.Requests;
using ClioSDK.Tests.TestHelpers;
using FluentAssertions;
using Xunit;

namespace ClioSDK.Tests.Integration;

public class ClioSDKIntegrationTests : TestBase
{
    private readonly ActivitiesClient _activitiesClient;
    private readonly MattersClient _mattersClient;
    private readonly BillsClient _billsClient;
    private readonly ContactsClient _contactsClient;
    private readonly UsersClient _usersClient;
    private readonly DocumentsClient _documentsClient;
    private readonly TasksClient _tasksClient;

    public ClioSDKIntegrationTests()
    {
        _activitiesClient = new ActivitiesClient(HttpClient);
        _mattersClient = new MattersClient(HttpClient);
        _billsClient = new BillsClient(HttpClient);
        _contactsClient = new ContactsClient(HttpClient);
        _usersClient = new UsersClient(HttpClient);
        _documentsClient = new DocumentsClient(HttpClient);
        _tasksClient = new TasksClient(HttpClient);
    }

    #region Complete Matter Workflow Tests
    [Fact]
    public async System.Threading.Tasks.Task CompleteMatterWorkflow_ShouldCreateAndManageMatter()
    {
        // Arrange - Create contact
        var contactRequest = TestDataFactory.CreateContactRequest();
        var createdContact = TestDataFactory.CreateContact(123);

        // Setup mock responses
        SetupMockResponse(TestDataFactory.CreateApiResponse(createdContact));

        // Act - Create contact
        var contactResult = await _contactsClient.CreateAsync(contactRequest);
        contactResult.Should().NotBeNull();

        // Arrange - Create matter
        SetupMockResponse(TestDataFactory.CreateApiResponse(TestDataFactory.CreateMatter(456)));

        var matterRequest = new MatterRequest
        {
            Description = "Integration Test Matter",
            Client = new ContactReferenceRequest { Id = 123 },
            PracticeArea = new PracticeAreaReferenceRequest { Id = 5 },
            Status = "Open",
            BillingMethod = "hourly",
            OpenDate = DateTime.UtcNow
        };

        // Act - Create matter
        var matterResult = await _mattersClient.CreateAsync(matterRequest);
        matterResult.Should().NotBeNull();

        // Arrange - Create activities
        var activityRequest = new ActivityRequest
        {
            Description = "Legal research for integration test",
            Matter = new MatterReferenceRequest { Id = 456 },
            User = new UserReferenceRequest { Id = 789 },
            Quantity = 2.5m,
            Price = 350m,
            Billable = true,
            TimeEntry = true,
            Date = DateTime.UtcNow
        };

        SetupMockResponse(TestDataFactory.CreateApiResponse(TestDataFactory.CreateActivity(789)));

        // Act - Create activity
        var activityResult = await _activitiesClient.CreateAsync(activityRequest);
        activityResult.Should().NotBeNull();

        // Assert - All workflow steps should succeed
        contactResult.Data.Should().NotBeNull();
        matterResult.Data.Should().NotBeNull();
        activityResult.Data.Should().NotBeNull();
    }
    #endregion

    #region Document Management Workflow
    [Fact]
    public async System.Threading.Tasks.Task DocumentManagementWorkflow_ShouldHandleDocumentLifecycle()
    {
        // Arrange - Create matter for documents
        var matter = TestDataFactory.CreateMatter(123);
        SetupMockResponse(TestDataFactory.CreatePaginatedResponse(new List<Matter> { matter }));

        // Act - Get matters
        var mattersResult = await _mattersClient.GetAsync();
        mattersResult.Should().NotBeNull();

        // Arrange - Create document
        var documentRequest = new DocumentRequest
        {
            Name = "Integration Test Document.pdf",
            Description = "Test document for integration",
            Matter = new MatterReferenceRequest { Id = 123 }
        };

        var document = TestDataFactory.CreateDocument(456);
        SetupMockResponse(TestDataFactory.CreateApiResponse(document));

        // Act - Create document
        var documentResult = await _documentsClient.CreateAsync(documentRequest);
        documentResult.Should().NotBeNull();

        // Arrange - Update document
        var updateRequest = new DocumentRequest
        {
            Name = "Updated Integration Test Document.pdf",
            Description = "Updated test document"
        };

        SetupMockResponse(TestDataFactory.CreateApiResponse(document));

        // Act - Update document
        var updateResult = await _documentsClient.UpdateAsync(456, updateRequest);
        updateResult.Should().NotBeNull();

        // Assert
        mattersResult.Data.Should().HaveCount(1);
        documentResult.Data.Should().NotBeNull();
        updateResult.Data.Should().NotBeNull();
    }
    #endregion

    #region User and Task Management Workflow
    [Fact]
    public async System.Threading.Tasks.Task UserTaskWorkflow_ShouldManageUserTasks()
    {
        // Arrange - Get users
        var users = TestDataFactory.CreateList(2, TestDataFactory.CreateUser);
        SetupMockResponse(TestDataFactory.CreatePaginatedResponse(users));

        // Act - Get users
        var usersResult = await _usersClient.GetAsync();
        usersResult.Should().NotBeNull();

        // Arrange - Create task
        var taskRequest = new TaskRequest
        {
            Name = "Integration Test Task",
            Description = "Test task for integration",
            Assignee = new UserReferenceRequest { Id = users[0].Id },
            DueDate = DateTime.UtcNow.AddDays(7),
            Priority = 2
        };

        var task = TestDataFactory.CreateTask(123);
        SetupMockResponse(TestDataFactory.CreateApiResponse(task));

        // Act - Create task
        var taskResult = await _tasksClient.CreateAsync(taskRequest);
        taskResult.Should().NotBeNull();

        // Assert
        usersResult.Data.Should().HaveCount(2);
        taskResult.Data.Should().NotBeNull();
        taskResult.Data.Assignee.Should().NotBeNull();
    }
    #endregion

    #region Error Handling Workflow
    [Fact]
    public async System.Threading.Tasks.Task ErrorHandlingWorkflow_ShouldGracefullyHandleErrors()
    {
        // Arrange - Setup error responses
        SetupMockErrorResponse(System.Net.HttpStatusCode.NotFound, "Matter not found");
        SetupMockErrorResponse(System.Net.HttpStatusCode.Unauthorized, "Invalid API key");
        SetupMockErrorResponse(System.Net.HttpStatusCode.Forbidden, "Access denied");

        // Act & Assert - Handle different error scenarios
        await Assert.ThrowsAsync<HttpRequestException>(() => _mattersClient.GetAsync(999));
        await Assert.ThrowsAsync<HttpRequestException>(() => _contactsClient.GetAsync());
        await Assert.ThrowsAsync<HttpRequestException>(() => _activitiesClient.GetAsync());
    }
    #endregion

    #region Pagination and Filtering Tests
    [Fact]
    public async System.Threading.Tasks.Task PaginationWorkflow_ShouldHandleLargeDataSets()
    {
        // Arrange - Create large dataset
        var matters = TestDataFactory.CreateList(100, TestDataFactory.CreateMatter);
        var paginatedResponse = new PaginatedResponse<Matter>
        {
            Data = matters.Take(25).ToList(),
            Meta = new Meta
            {
                Pagination = new Pagination
                {
                    TotalCount = 100,
                    Page = 1,
                    PerPage = 25,
                    HasMore = true
                }
            }
        };

        SetupMockResponse(paginatedResponse);

        // Act - Get paginated results
        var result = await _mattersClient.GetAsync(new QueryOptions
        {
            Limit = 25,
            Offset = 0
        });

        // Assert
        result.Should().NotBeNull();
        result.Data.Should().HaveCount(25);
        result.Meta.Pagination.Should().NotBeNull();
        result.Meta.Pagination.TotalCount.Should().Be(100);
        result.Meta.Pagination.HasMore.Should().BeTrue();
    }
    #endregion

    #region Data Consistency Tests
    [Fact]
    public async System.Threading.Tasks.Task DataConsistencyWorkflow_ShouldMaintainDataIntegrity()
    {
        // Arrange - Create related entities
        var contact = TestDataFactory.CreateContact(123);
        var matter = TestDataFactory.CreateMatter(456);
        var activity = TestDataFactory.CreateActivity(789);

        // Setup related data
        matter.Client = new ContactReference { Id = contact.Id, Name = contact.Name };
        activity.Matter = new MatterReference { Id = matter.Id, DisplayNumber = matter.DisplayNumber };
        activity.User = new UserReference { Id = 1, Name = "Test User" };

        SetupMockResponse(TestDataFactory.CreateApiResponse(contact));
        SetupMockResponse(TestDataFactory.CreateApiResponse(matter));
        SetupMockResponse(TestDataFactory.CreateApiResponse(activity));

        // Act - Retrieve related entities
        var contactResult = await _contactsClient.GetAsync(123);
        var matterResult = await _mattersClient.GetAsync(456);
        var activityResult = await _activitiesClient.GetAsync(789);

        // Assert - Verify data consistency
        contactResult.Should().NotBeNull();
        matterResult.Should().NotBeNull();
        activityResult.Should().NotBeNull();

        // Verify relationships
        matterResult.Data.Client.Should().NotBeNull();
        activityResult.Data.Matter.Should().NotBeNull();
        activityResult.Data.User.Should().NotBeNull();
    }
    #endregion
}