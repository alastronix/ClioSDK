using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using ClioSDK.Models;
using ClioSDK.Models.Requests;
using System.Threading.Tasks;

namespace ClioSDK.Tests.TestHelpers;

public static class TestDataFactory
{
    private static readonly Random _random = new Random();

    #region Activity Tests
    public static Activity CreateActivity(int id = 1)
    {
        return new Activity
        {
            Id = id,
            Description = $"Test Activity {id}",
            Date = DateTime.UtcNow.AddDays(-_random.Next(1, 30)),
            Quantity = (decimal)(_random.NextDouble() * 8 + 0.5),
            Price = (decimal)(_random.NextDouble() * 500 + 100),
            Total = (decimal)(_random.NextDouble() * 1000 + 200),
            Billable = _random.Next(0, 2) == 1,
            Billed = false,
            TimeEntry = true,
            Expense = false,
            Note = false,
            User = new UserReference { Id = _random.Next(1, 10) },
            Matter = new MatterReference { Id = _random.Next(1, 20), DisplayNumber = $"M{_random.Next(1000, 9999)}" },
            Contact = new ContactReference { Id = _random.Next(1, 50) },
            CreatedAt = DateTime.UtcNow.AddDays(-_random.Next(1, 365)),
            UpdatedAt = DateTime.UtcNow.AddHours(-_random.Next(1, 24))
        };
    }

    public static ClioSDK.Models.Requests.ActivityRequest CreateActivityRequest()
    {
        return new ClioSDK.Models.Requests.ActivityRequest
        {
            Description = "New Test Activity",
            Date = DateTime.UtcNow,
            Quantity = 2.5m,
            Price = 350m,
            Billable = true,
            TimeEntry = true,
            Matter = new MatterReferenceRequest { Id = 123 },
            User = new UserReferenceRequest { Id = 456 },
            NoteDetails = "Test activity details"
        };
    }
    #endregion

    #region Matter Tests
    public static Matter CreateMatter(int id = 1)
    {
        return new Matter
        {
            Id = id,
            Description = $"Test Matter {id} - Legal Case",
            DisplayNumber = $"M{id + 1000:D4}",
            Status = "Open",
            BillingMethod = "hourly",
            OpenDate = DateTime.UtcNow.AddDays(-_random.Next(1, 365)),
            CloseDate = null,
            Client = new ContactReference { Id = _random.Next(1, 50) },
            PracticeArea = new PracticeAreaReference { Id = _random.Next(1, 10) },
            Assignee = new UserReference { Id = _random.Next(1, 20) },
            CustomFieldValues = new List<CustomFieldValue>(),
            CreatedAt = DateTime.UtcNow.AddDays(-_random.Next(1, 365)),
            UpdatedAt = DateTime.UtcNow.AddHours(-_random.Next(1, 24))
        };
    }

    public static ClioSDK.Models.Requests.MatterRequest CreateMatterRequest()
    {
        return new ClioSDK.Models.Requests.MatterRequest
        {
            Description = "New Test Matter - Sample Case",
            DisplayNumber = "M9999",
            Status = "Open",
            BillingMethod = "hourly",
            OpenDate = DateTime.UtcNow,
            Client = new ContactReferenceRequest { Id = 123 },
            PracticeArea = new PracticeAreaReferenceRequest { Id = 5 },
            Assignee = new UserReferenceRequest { Id = 456 }
        };
    }
    #endregion

    #region Contact Tests
    public static Contact CreateContact(int id = 1)
    {
        return new Contact
        {
            Id = id,
            Name = $"Test Contact {id}",
            FirstName = $"Test{id}",
            LastName = $"Contact{id}",
            Type = "Person",
            PrimaryEmail = $"test{id}@example.com",
            PrimaryPhone = $"555-{_random.Next(100, 999)}-{_random.Next(1000, 9999):D4}",
            Address = new Address
            {
                Street = $"{_random.Next(100, 999)} Test St",
                City = "Test City",
                State = "TS",
                PostalCode = $"{_random.Next(10000, 99999)}",
                Country = "USA"
            },
            Company = id % 2 == 0,
            Client = true,
            CreatedAt = DateTime.UtcNow.AddDays(-_random.Next(1, 365)),
            UpdatedAt = DateTime.UtcNow.AddHours(-_random.Next(1, 24))
        };
    }

    public static ClioSDK.Models.Requests.ContactRequest CreateContactRequest()
    {
        return new ClioSDK.Models.Requests.ContactRequest
        {
            Name = "New Test Contact",
            FirstName = "New",
            LastName = "Contact",
            Type = "Person",
            PrimaryEmail = "newcontact@example.com",
            PrimaryPhone = "555-123-4567",
            Company = false,
            Client = true
        };
    }
    #endregion

    #region Bill Tests
    public static Bill CreateBill(int id = 1)
    {
        return new Bill
        {
            Id = id,
            Number = $"B{id:D6}",
            IssueDate = DateTime.UtcNow.AddDays(-_random.Next(1, 30)),
            DueDate = DateTime.UtcNow.AddDays(_random.Next(1, 30)),
            Total = (decimal)(_random.NextDouble() * 5000 + 500),
            Balance = (decimal)(_random.NextDouble() * 2000),
            Status = "sent",
            Client = new ContactReference { Id = _random.Next(1, 50) },
            Matter = new MatterReference { Id = _random.Next(1, 20), DisplayNumber = $"M{_random.Next(1000, 9999)}" },
            CreatedAt = DateTime.UtcNow.AddDays(-_random.Next(1, 365)),
            UpdatedAt = DateTime.UtcNow.AddHours(-_random.Next(1, 24))
        };
    }

    public static BillRequest CreateBillRequest()
    {
        return new BillRequest
        {
            IssueDate = DateTime.UtcNow,
            DueDate = DateTime.UtcNow.AddDays(30),
            Client = new ContactReferenceRequest { Id = 123 },
            Matter = new MatterReferenceRequest { Id = 456 }
        };
    }
    #endregion

    #region Document Tests
    public static Document CreateDocument(int id = 1)
    {
        return new Document
        {
            Id = id,
            Name = $"Test Document {id}.pdf",
            Description = $"Test document description {id}",
            Size = _random.Next(1000, 10000000),
            ContentType = "application/pdf",
            Url = $"https://example.com/docs/{id}",
            DocumentCategory = new DocumentCategoryReference { Id = _random.Next(1, 10) },
            Matter = new MatterReference { Id = _random.Next(1, 20), DisplayNumber = $"M{_random.Next(1000, 9999)}" },
            Contact = new ContactReference { Id = _random.Next(1, 50) },
            CreatedAt = DateTime.UtcNow.AddDays(-_random.Next(1, 365)),
            UpdatedAt = DateTime.UtcNow.AddHours(-_random.Next(1, 24))
        };
    }

    public static ClioSDK.Models.Requests.DocumentRequest CreateDocumentRequest()
    {
        return new ClioSDK.Models.Requests.DocumentRequest
        {
            Name = "New Test Document.pdf",
            Description = "New test document",
            DocumentCategory = new DocumentCategoryReferenceRequest { Id = 5 },
            Matter = new MatterReferenceRequest { Id = 123 },
            Contact = new ContactReferenceRequest { Id = 456 }
        };
    }
    #endregion

    #region User Tests
    public static User CreateUser(int id = 1)
    {
        return new User
        {
            Id = id,
            Name = $"Test User {id}",
            Email = $"user{id}@example.com",
            FirstName = $"Test{id}",
            LastName = $"User{id}",
            TimeZone = "America/New_York",
            Enabled = true,
            Role = "Attorney",
            CreatedAt = DateTime.UtcNow.AddDays(-_random.Next(1, 365)),
            UpdatedAt = DateTime.UtcNow.AddHours(-_random.Next(1, 24))
        };
    }
    #endregion

    #region Task Tests
    public static Task CreateTask(int id = 1)
    {
        return new Task
        {
            Id = id,
            Name = $"Test Task {id}",
            Description = $"Test task description {id}",
            DueDate = DateTime.UtcNow.AddDays(_random.Next(1, 30)),
            Priority = _random.Next(1, 4),
            Status = "Not Started",
            Assignee = new UserReference { Id = _random.Next(1, 10) },
            Matter = new MatterReference { Id = _random.Next(1, 20), DisplayNumber = $"M{_random.Next(1000, 9999)}" },
            CreatedAt = DateTime.UtcNow.AddDays(-_random.Next(1, 365)),
            UpdatedAt = DateTime.UtcNow.AddHours(-_random.Next(1, 24))
        };
    }

    public static TaskRequest CreateTaskRequest()
    {
        return new ClioSDK.Models.Requests.TaskRequest
        {
            Name = "New Test Task",
            Description = "New task description",
            DueDate = DateTime.UtcNow.AddDays(7),
            Priority = 2,
            Assignee = new UserReferenceRequest { Id = 123 },
            Matter = new MatterReferenceRequest { Id = 456 }
        };
    }
    #endregion

    #region Calendar Tests
    public static Calendar CreateCalendar(int id = 1)
    {
        return new Calendar
        {
            Id = id,
            Name = $"Test Calendar {id}",
            Description = $"Test calendar description {id}",
            Color = $"#{id:X6}",
            Default = id == 1,
            CreatedAt = DateTime.UtcNow.AddDays(-_random.Next(1, 365)),
            UpdatedAt = DateTime.UtcNow.AddHours(-_random.Next(1, 24))
        };
    }

    public static CalendarRequest CreateCalendarRequest()
    {
        return new CalendarRequest
        {
            Name = "New Test Calendar",
            Description = "New calendar description",
            Color = "#33FF57",
            Default = false
        };
    }
    #endregion

    #region TrustAccount Tests
    public static TrustAccount CreateTrustAccount(int id = 1)
    {
        return new TrustAccount
        {
            Id = id,
            Name = $"Test Trust Account {id}",
            BankName = $"Test Bank {id}",
            AccountNumber = $"****{id:D4}",
            Type = "IOLTA",
            Balance = (decimal)(_random.NextDouble() * 50000 + 1000),
            ReconciledBalance = (decimal)(_random.NextDouble() * 45000 + 1000),
            CreatedAt = DateTime.UtcNow.AddDays(-_random.Next(1, 365)),
            UpdatedAt = DateTime.UtcNow.AddHours(-_random.Next(1, 24))
        };
    }

    public static TrustAccountRequest CreateTrustAccountRequest()
    {
        return new TrustAccountRequest
        {
            Name = "New Test Trust Account",
            BankName = "New Test Bank",
            AccountNumber = "****1234",
            Type = "IOLTA"
        };
    }
    #endregion

    #region Helper Methods
    public static List<T> CreateList<T>(int count, Func<int, T> factory) where T : class
    {
        var list = new List<T>();
        for (int i = 1; i <= count; i++)
        {
            list.Add(factory(i));
        }
        return list;
    }

    public static ClioSDK.Core.PaginatedResponse<T> CreateClioSDK.Core.PaginatedResponse<T>(List<T> data) where T : class
    {
        return new ClioSDK.Core.ClioSDK.Core.PaginatedResponse<T>
        {
            Data = data,
            Meta = new Meta
            {
                Pagination = new Pagination
                {
                    TotalCount = data.Count,
                    Page = 1,
                    PerPage = data.Count,
                    HasMore = false
                }
            }
        };
    }

    public static ClioSDK.Core.ApiResponse<T> CreateClioSDK.Core.ApiResponse<T>(T data) where T : class
    {
        return new ClioSDK.Core.ClioSDK.Core.ApiResponse<T>
        {
            Data = data,
            Meta = new Meta()
        };
    }
    #endregion
}