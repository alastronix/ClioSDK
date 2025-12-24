# Clio SDK Examples

This document provides comprehensive examples of using the Clio SDK in real-world scenarios.

## Table of Contents
- [Basic CRUD Operations](#basic-crud-operations)
- [Time Tracking](#time-tracking)
- [Document Management](#document-management)
- [Financial Operations](#financial-operations)
- [Communication Management](#communication-management)
- [Calendar Management](#calendar-management)
- [Advanced Querying](#advanced-querying)
- [Error Handling](#error-handling)
- [Batch Operations](#batch-operations)
- [Reporting](#reporting)

---

## Basic CRUD Operations

### Matter Management
```csharp
using ClioSDK;

public class MatterService
{
    private readonly ClioClient _clio;
    
    public MatterService(string apiKey)
    {
        _clio = new ClioClient(apiKey);
    }
    
    // Create a new matter
    public async Task<Matter> CreateNewMatterAsync()
    {
        var matterRequest = new MatterRequest
        {
            Description = "Employment Discrimination Case",
            Status = "Open",
            Client = new ContactReference { Id = 12345 },
            PracticeArea = new PracticeAreaReference { Id = 789 },
            OpenDate = DateTime.UtcNow,
            BillingMethod = "hourly",
            Calendar = new CalendarReference { Id = 456 }
        };
        
        var response = await _clio.Matters.CreateAsync(matterRequest);
        return response.Data;
    }
    
    // Get all open matters for a client
    public async Task<List<Matter>> GetClientOpenMattersAsync(int clientId)
    {
        var options = new QueryOptions
        {
            QueryParams = new Dictionary<string, object>
            {
                ["client_id"] = clientId,
                ["status"] = "Open"
            }
        };
        
        var response = await _clio.Matters.GetAsync(options);
        return response.Data.ToList();
    }
    
    // Update matter status
    public async Task UpdateMatterStatusAsync(int matterId, string newStatus)
    {
        var updateRequest = new MatterRequest
        {
            Status = newStatus,
            CloseDate = newStatus == "Closed" ? DateTime.UtcNow : null
        };
        
        await _clio.Matters.UpdateAsync(matterId, updateRequest);
    }
}
```

### Contact Management
```csharp
public class ContactService
{
    private readonly ClioClient _clio;
    
    public ContactService(ClioClient clio)
    {
        _clio = clio;
    }
    
    // Create a new client contact
    public async Task<Contact> CreateClientContactAsync()
    {
        var contactRequest = new ContactRequest
        {
            Name = "John Smith Corporation",
            Type = "Organization",
            Company = "John Smith Corporation",
            EmailAddress = "contact@johnsmithcorp.com",
            PhoneNumber = "555-0123",
            Address = "123 Business St, Suite 100, New York, NY 10001"
        };
        
        var response = await _clio.Contacts.CreateAsync(contactRequest);
        return response.Data;
    }
    
    // Add individual contact to organization
    public async Task<Contact> AddContactPersonAsync(int organizationId)
    {
        var personRequest = new ContactRequest
        {
            Name = "Jane Doe",
            Type = "Person",
            FirstName = "Jane",
            LastName = "Doe",
            EmailAddress = "jane.doe@johnsmithcorp.com",
            PhoneNumber = "555-0124",
            Company = new ContactReference { Id = organizationId }
        };
        
        var response = await _clio.Contacts.CreateAsync(personRequest);
        return response.Data;
    }
    
    // Search contacts by name
    public async Task<List<Contact>> SearchContactsAsync(string searchTerm)
    {
        var options = new QueryOptions
        {
            QueryParams = new Dictionary<string, object>
            {
                ["name"] = searchTerm
            }
        };
        
        var response = await _clio.Contacts.GetAsync(options);
        return response.Data.ToList();
    }
}
```

---

## Time Tracking

### Activity Logging
```csharp
public class TimeTrackingService
{
    private readonly ClioClient _clio;
    
    public TimeTrackingService(ClioClient clio)
    {
        _clio = clio;
    }
    
    // Log billable time
    public async Task<Activity> LogBillableTimeAsync(
        int matterId, 
        string description, 
        decimal hours, 
        DateTime activityDate)
    {
        var activityRequest = new ActivityRequest
        {
            Description = description,
            Matter = new MatterReference { Id = matterId },
            Quantity = hours,
            Billable = true,
            Date = activityDate,
            Type = "TimeEntry",
            User = new UserReference { Id = GetCurrentUserId() },
            Price = 250.00m, // Hourly rate
            ActivityDescription = new ActivityDescriptionReference { Id = 1 }
        };
        
        var response = await _clio.Activities.CreateAsync(activityRequest);
        return response.Data;
    }
    
    // Log non-billable administrative time
    public async Task<Activity> LogAdminTimeAsync(string description, decimal hours)
    {
        var activityRequest = new ActivityRequest
        {
            Description = description,
            Quantity = hours,
            Billable = false,
            Date = DateTime.UtcNow,
            Type = "TimeEntry",
            User = new UserReference { Id = GetCurrentUserId() }
        };
        
        var response = await _clio.Activities.CreateAsync(activityRequest);
        return response.Data;
    }
    
    // Get time entries for a date range
    public async Task<List<Activity>> GetTimeEntriesAsync(DateTime startDate, DateTime endDate)
    {
        var options = new QueryOptions
        {
            QueryParams = new Dictionary<string, object>
            {
                ["date[gte]"] = startDate.ToString("yyyy-MM-dd"),
                ["date[lte]"] = endDate.ToString("yyyy-MM-dd"),
                ["type"] = "TimeEntry",
                ["user_id"] = GetCurrentUserId()
            }
        };
        
        var response = await _clio.Activities.GetAsync(options);
        return response.Data.ToList();
    }
    
    // Update time entry description
    public async Task UpdateTimeEntryAsync(int activityId, string newDescription)
    {
        var updateRequest = new ActivityRequest
        {
            Description = newDescription
        };
        
        await _clio.Activities.UpdateAsync(activityId, updateRequest);
    }
    
    private int GetCurrentUserId()
    {
        // In a real application, get current user ID from authentication
        return 123;
    }
}
```

### Timer Management
```csharp
public class TimerService
{
    private readonly ClioClient _clio;
    
    public TimerService(ClioClient clio)
    {
        _clio = clio;
    }
    
    // Start a new timer
    public async Task<Timer> StartTimerAsync(int matterId, string description)
    {
        var timerRequest = new TimerRequest
        {
            Description = description,
            Matter = new MatterReference { Id = matterId },
            Duration = 0,
            StartedAt = DateTime.UtcNow,
            User = new UserReference { Id = GetCurrentUserId() }
        };
        
        var response = await _clio.Timers.CreateAsync(timerRequest);
        return response.Data;
    }
    
    // Stop a running timer
    public async Task<Timer> StopTimerAsync(int timerId)
    {
        var updateRequest = new TimerRequest
        {
            Duration = (int)DateTime.UtcNow.Subtract(DateTime.UtcNow.AddHours(-1)).TotalSeconds, // Example duration
            StoppedAt = DateTime.UtcNow
        };
        
        var response = await _clio.Timers.UpdateAsync(timerId, updateRequest);
        return response.Data;
    }
    
    // Get all running timers
    public async Task<List<Timer>> GetRunningTimersAsync()
    {
        var options = new QueryOptions
        {
            QueryParams = new Dictionary<string, object>
            {
                ["stopped_at"] = null
            }
        };
        
        var response = await _clio.Timers.GetAsync(options);
        return response.Data.ToList();
    }
}
```

---

## Document Management

### Document Upload and Organization
```csharp
public class DocumentService
{
    private readonly ClioClient _clio;
    
    public DocumentService(ClioClient clio)
    {
        _clio = clio;
    }
    
    // Upload document metadata (actual file upload handled separately)
    public async Task<Document> CreateDocumentRecordAsync(
        int matterId, 
        string fileName, 
        string description)
    {
        var documentRequest = new DocumentRequest
        {
            Name = fileName,
            Description = description,
            Matter = new MatterReference { Id = matterId },
            DocumentCategory = new DocumentCategoryReference { Id = 1 },
            CreatedAt = DateTime.UtcNow
        };
        
        var response = await _clio.Documents.CreateAsync(documentRequest);
        return response.Data;
    }
    
    // Organize documents into folders
    public async Task<Folder> CreateFolderAsync(string folderName, int? matterId = null)
    {
        var folderRequest = new FolderRequest
        {
            Name = folderName,
            Matter = matterId.HasValue ? new MatterReference { Id = matterId.Value } : null
        };
        
        var response = await _clio.Folders.CreateAsync(folderRequest);
        return response.Data;
    }
    
    // Move document to folder
    public async Task MoveDocumentToFolderAsync(int documentId, int folderId)
    {
        var updateRequest = new DocumentRequest
        {
            Folder = new FolderReference { Id = folderId }
        };
        
        await _clio.Documents.UpdateAsync(documentId, updateRequest);
    }
    
    // Get documents for matter
    public async Task<List<Document>> GetMatterDocumentsAsync(int matterId)
    {
        var options = new QueryOptions
        {
            QueryParams = new Dictionary<string, object>
            {
                ["matter_id"] = matterId
            }
        };
        
        var response = await _clio.Documents.GetAsync(options);
        return response.Data.ToList();
    }
    
    // Archive old documents
    public async Task ArchiveDocumentsAsync(int matterId, DateTime cutoffDate)
    {
        var documents = await GetMatterDocumentsAsync(matterId);
        var oldDocuments = documents.Where(d => d.CreatedAt < cutoffDate);
        
        foreach (var document in oldDocuments)
        {
            var archiveRequest = new DocumentArchiveRequest
            {
                Document = new DocumentReference { Id = document.Id },
                ArchivedAt = DateTime.UtcNow
            };
            
            await _clio.DocumentArchives.CreateAsync(archiveRequest);
        }
    }
}
```

### Document Versioning
```csharp
public class DocumentVersionService
{
    private readonly ClioClient _clio;
    
    public DocumentVersionService(ClioClient clio)
    {
        _clio = clio;
    }
    
    // Create new document version
    public async Task<DocumentVersion> CreateVersionAsync(
        int documentId, 
        string versionNotes)
    {
        var versionRequest = new DocumentVersionRequest
        {
            Document = new DocumentReference { Id = documentId },
            VersionNotes = versionNotes,
            CreatedAt = DateTime.UtcNow,
            User = new UserReference { Id = GetCurrentUserId() }
        };
        
        var response = await _clio.DocumentVersions.CreateAsync(versionRequest);
        return response.Data;
    }
    
    // Get version history
    public async Task<List<DocumentVersion>> GetVersionHistoryAsync(int documentId)
    {
        var options = new QueryOptions
        {
            QueryParams = new Dictionary<string, object>
            {
                ["document_id"] = documentId
            },
            OrderBy = "created_at DESC"
        };
        
        var response = await _clio.DocumentVersions.GetAsync(options);
        return response.Data.ToList();
    }
}
```

---

## Financial Operations

### Billing and Invoicing
```csharp
public class BillingService
{
    private readonly ClioClient _clio;
    
    public BillingService(ClioClient clio)
    {
        _clio = clio;
    }
    
    // Create a bill from unbilled activities
    public async Task<Bill> CreateBillAsync(int matterId, DateTime issueDate)
    {
        // Get unbilled activities for the matter
        var unbilledOptions = new QueryOptions
        {
            QueryParams = new Dictionary<string, object>
            {
                ["matter_id"] = matterId,
                ["billable"] = true,
                ["billed"] = false
            }
        };
        
        var activities = await _clio.Activities.GetAsync(unbilledOptions);
        
        // Create line items from activities
        var lineItems = activities.Data.Select(activity => new LineItemRequest
        {
            Activity = new ActivityReference { Id = activity.Id },
            Description = activity.Description,
            Quantity = activity.Quantity,
            UnitPrice = activity.Price ?? 0m,
            Total = activity.Quantity * (activity.Price ?? 0m)
        }).ToList();
        
        // Create the bill
        var billRequest = new BillRequest
        {
            Matter = new MatterReference { Id = matterId },
            IssueDate = issueDate,
            DueDate = issueDate.AddDays(30),
            LineItems = lineItems.Select(li => new LineItemReference { Id = li.Id }).ToList(),
            Status = "Draft"
        };
        
        var response = await _clio.Bills.CreateAsync(billRequest);
        return response.Data;
    }
    
    // Apply payment to bill
    public async Task<Allocation> ApplyPaymentAsync(int billId, decimal paymentAmount)
    {
        var allocationRequest = new AllocationRequest
        {
            Amount = paymentAmount,
            Bill = new BillReference { Id = billId },
            PaymentDate = DateTime.UtcNow,
            Notes = "Client payment via check"
        };
        
        var response = await _clio.Allocations.CreateAsync(allocationRequest);
        return response.Data;
    }
    
    // Get outstanding balances
    public async Task<List<OutstandingClientBalance>> GetOutstandingBalancesAsync()
    {
        var response = await _clio.OutstandingClientBalances.GetAsync();
        return response.Data.Where(b => b.Balance > 0).ToList();
    }
}
```

### Trust Accounting
```csharp
public class TrustService
{
    private readonly ClioClient _clio;
    
    public TrustService(ClioClient clio)
    {
        _clio = clio;
    }
    
    // Create trust request
    public async Task<TrustRequest> CreateTrustRequestAsync(
        int clientId, 
        decimal amount, 
        string purpose)
    {
        var trustRequest = new TrustRequestRequest
        {
            Client = new ContactReference { Id = clientId },
            Amount = amount,
            Purpose = purpose,
            RequestDate = DateTime.UtcNow,
            Status = "Pending"
        };
        
        var response = await _clio.TrustRequests.CreateAsync(trustRequest);
        return response.Data;
    }
    
    // Record trust transaction
    public async Task<TrustLineItem> RecordTrustTransactionAsync(
        int trustAccountId, 
        decimal amount, 
        string description, 
        bool isDeposit)
    {
        var lineItemRequest = new TrustLineItemRequest
        {
            TrustAccount = new TrustAccountReference { Id = trustAccountId },
            Amount = amount,
            Description = description,
            TransactionDate = DateTime.UtcNow,
            IsDeposit = isDeposit
        };
        
        var response = await _clio.TrustLineItems.CreateAsync(lineItemRequest);
        return response.Data;
    }
    
    // Get trust account balance
    public async Task<decimal> GetTrustAccountBalanceAsync(int trustAccountId)
    {
        var response = await _clio.TrustAccounts.GetAsync(trustAccountId);
        return response.Data.CurrentBalance ?? 0m;
    }
}
```

---

## Communication Management

### Conversations and Messaging
```csharp
public class CommunicationService
{
    private readonly ClioClient _clio;
    
    public CommunicationService(ClioClient clio)
    {
        _clio = clio;
    }
    
    // Start a new conversation
    public async Task<Conversation> StartConversationAsync(int matterId, int participantId)
    {
        var conversationRequest = new ConversationRequest
        {
            Matter = new MatterReference { Id = matterId },
            Participants = new List<ContactReference>
            {
                new ContactReference { Id = participantId }
            },
            Subject = $"Matter #{matterId} Discussion"
        };
        
        var response = await _clio.Conversations.CreateAsync(conversationRequest);
        return response.Data;
    }
    
    // Send message in conversation
    public async Task<ConversationMessage> SendMessageAsync(
        int conversationId, 
        string messageBody, 
        int senderId)
    {
        var messageRequest = new ConversationMessageRequest
        {
            Body = messageBody,
            Conversation = new ConversationReference { Id = conversationId },
            User = new UserReference { Id = senderId },
            SentAt = DateTime.UtcNow
        };
        
        var response = await _clio.ConversationMessages.CreateAsync(messageRequest);
        return response.Data;
    }
    
    // Add note to matter
    public async Task<Note> AddNoteAsync(int matterId, string noteContent, bool isPrivate = false)
    {
        var noteRequest = new NoteRequest
        {
            Detail = noteContent,
            Matter = new MatterReference { Id = matterId },
            Private = isPrivate,
            CreatedAt = DateTime.UtcNow,
            User = new UserReference { Id = GetCurrentUserId() }
        };
        
        var response = await _clio.Notes.CreateAsync(noteRequest);
        return response.Data;
    }
    
    // Get conversation history
    public async Task<List<ConversationMessage>> GetConversationHistoryAsync(
        int conversationId, 
        int limit = 50)
    {
        var options = new QueryOptions
        {
            QueryParams = new Dictionary<string, object>
            {
                ["conversation_id"] = conversationId
            },
            Limit = limit,
            OrderBy = "sent_at DESC"
        };
        
        var response = await _clio.ConversationMessages.GetAsync(options);
        return response.Data.ToList();
    }
}
```

---

## Calendar Management

### Calendar Events and Scheduling
```csharp
public class CalendarService
{
    private readonly ClioClient _clio;
    
    public CalendarService(ClioClient clio)
    {
        _clio = clio;
    }
    
    // Schedule a calendar event
    public async Task<CalendarEntry> ScheduleEventAsync(
        int matterId, 
        string title, 
        DateTime startDateTime, 
        DateTime endDateTime,
        List<int> participantIds)
    {
        var calendarEntryRequest = new CalendarEntryRequest
        {
            Summary = title,
            StartAt = startDateTime,
            EndAt = endDateTime,
            Matter = new MatterReference { Id = matterId },
            Calendar = new CalendarReference { Id = GetDefaultCalendarId() },
            Participants = participantIds.Select(id => new ContactReference { Id = id }).ToList(),
            AllDay = false,
            ReminderMinutes = 15
        };
        
        var response = await _clio.CalendarEntries.CreateAsync(calendarEntryRequest);
        return response.Data;
    }
    
    // Schedule court appearance
    public async Task<CalendarEntry> ScheduleCourtAppearanceAsync(
        int matterId, 
        string courtName, 
        DateTime dateTime, 
        int estimatedDurationMinutes)
    {
        var eventRequest = new CalendarEntryRequest
        {
            Summary = $"Court Appearance: {courtName}",
            StartAt = dateTime,
            EndAt = dateTime.AddMinutes(estimatedDurationMinutes),
            Matter = new MatterReference { Id = matterId },
            Calendar = new CalendarReference { Id = GetDefaultCalendarId() },
            CalendarEntryEventType = new CalendarEntryEventTypeReference { Id = GetCourtEventTypeId() },
            Location = courtName,
            AllDay = false,
            ReminderMinutes = 60 // Remind 1 hour before court
        };
        
        var response = await _clio.CalendarEntries.CreateAsync(eventRequest);
        return response.Data;
    }
    
    // Get upcoming events for the week
    public async Task<List<CalendarEntry>> GetUpcomingEventsAsync()
    {
        var now = DateTime.UtcNow;
        var weekFromNow = now.AddDays(7);
        
        var options = new QueryOptions
        {
            QueryParams = new Dictionary<string, object>
            {
                ["start_at[gte]"] = now.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                ["start_at[lte]"] = weekFromNow.ToString("yyyy-MM-ddTHH:mm:ssZ")
            },
            OrderBy = "start_at ASC"
        };
        
        var response = await _clio.CalendarEntries.GetAsync(options);
        return response.Data.ToList();
    }
    
    // Update event reminder
    public async Task UpdateEventReminderAsync(int eventId, int reminderMinutes)
    {
        var updateRequest = new CalendarEntryRequest
        {
            ReminderMinutes = reminderMinutes
        };
        
        await _clio.CalendarEntries.UpdateAsync(eventId, updateRequest);
    }
    
    private int GetDefaultCalendarId() => 1; // In real app, get from configuration
    private int GetCourtEventTypeId() => 2; // In real app, get from API
}
```

---

## Advanced Querying

### Complex Filtering and Pagination
```csharp
public class QueryService
{
    private readonly ClioClient _clio;
    
    public QueryService(ClioClient clio)
    {
        _clio = clio;
    }
    
    // Get matters with complex filtering
    public async Task<List<Matter>> GetFilteredMattersAsync(MatterFilter filter)
    {
        var queryParams = new Dictionary<string, object>();
        
        if (filter.ClientId.HasValue)
            queryParams["client_id"] = filter.ClientId.Value;
        
        if (!string.IsNullOrEmpty(filter.Status))
            queryParams["status"] = filter.Status;
        
        if (filter.PracticeAreaId.HasValue)
            queryParams["practice_area_id"] = filter.PracticeAreaId.Value;
        
        if (filter.OpenDateFrom.HasValue)
            queryParams["open_date[gte]"] = filter.OpenDateFrom.Value.ToString("yyyy-MM-dd");
        
        if (filter.OpenDateTo.HasValue)
            queryParams["open_date[lte]"] = filter.OpenDateTo.Value.ToString("yyyy-MM-dd");
        
        var options = new QueryOptions
        {
            QueryParams = queryParams,
            Limit = filter.PageSize,
            Offset = (filter.Page - 1) * filter.PageSize,
            Fields = filter.Fields ?? "id,description,status,client,practice_area,open_date",
            OrderBy = filter.OrderBy ?? "open_date DESC"
        };
        
        var response = await _clio.Matters.GetAsync(options);
        return response.Data.ToList();
    }
    
    // Get activities with date range and billable status
    public async Task<List<Activity>> GetActivitiesReportAsync(
        DateTime startDate, 
        DateTime endDate, 
        bool? billableOnly = null)
    {
        var queryParams = new Dictionary<string, object>
        {
            ["date[gte]"] = startDate.ToString("yyyy-MM-dd"),
            ["date[lte]"] = endDate.ToString("yyyy-MM-dd"),
            ["type"] = "TimeEntry"
        };
        
        if (billableOnly.HasValue)
            queryParams["billable"] = billableOnly.Value;
        
        var options = new QueryOptions
        {
            QueryParams = queryParams,
            OrderBy = "date DESC,created_at DESC"
        };
        
        var response = await _clio.Activities.GetAsync(options);
        return response.Data.ToList();
    }
    
    // Search across multiple criteria
    public async Task<List<Contact>> SearchContactsAsync(ContactSearchCriteria criteria)
    {
        var queryParams = new Dictionary<string, object>();
        
        if (!string.IsNullOrEmpty(criteria.Name))
            queryParams["name"] = criteria.Name;
        
        if (!string.IsNullOrEmpty(criteria.EmailAddress))
            queryParams["email_address"] = criteria.EmailAddress;
        
        if (!string.IsNullOrEmpty(criteria.PhoneNumber))
            queryParams["phone_number"] = criteria.PhoneNumber;
        
        if (!string.IsNullOrEmpty(criteria.Type))
            queryParams["type"] = criteria.Type;
        
        var options = new QueryOptions
        {
            QueryParams = queryParams,
            Limit = 100
        };
        
        var response = await _clio.Contacts.GetAsync(options);
        return response.Data.ToList();
    }
}

// Supporting classes
public class MatterFilter
{
    public int? ClientId { get; set; }
    public string? Status { get; set; }
    public int? PracticeAreaId { get; set; }
    public DateTime? OpenDateFrom { get; set; }
    public DateTime? OpenDateTo { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 50;
    public string? Fields { get; set; }
    public string? OrderBy { get; set; }
}

public class ContactSearchCriteria
{
    public string? Name { get; set; }
    public string? EmailAddress { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Type { get; set; }
}
```

---

## Error Handling

### Comprehensive Error Management
```csharp
public class RobustClioService
{
    private readonly ClioClient _clio;
    private readonly ILogger _logger;
    
    public RobustClioService(ClioClient clio, ILogger logger)
    {
        _clio = clio;
        _logger = logger;
    }
    
    // Execute API call with retry logic
    public async Task<T> ExecuteWithRetryAsync<T>(
        Func<Task<T>> apiCall, 
        int maxRetries = 3)
    {
        for (int attempt = 1; attempt <= maxRetries; attempt++)
        {
            try
            {
                return await apiCall();
            }
            catch (ClioApiException ex) when (ex.StatusCode == 429) // Rate limited
            {
                if (attempt == maxRetries)
                    throw;
                
                var delay = TimeSpan.FromSeconds(Math.Pow(2, attempt)); // Exponential backoff
                _logger.LogWarning($"Rate limited. Retrying in {delay.TotalSeconds} seconds (attempt {attempt}/{maxRetries})");
                await Task.Delay(delay);
            }
            catch (HttpRequestException ex) when (attempt < maxRetries)
            {
                var delay = TimeSpan.FromSeconds(attempt * 2);
                _logger.LogWarning($"Network error. Retrying in {delay.TotalSeconds} seconds (attempt {attempt}/{maxRetries})");
                await Task.Delay(delay);
            }
        }
        
        throw new InvalidOperationException("Max retries exceeded");
    }
    
    // Safe API call with detailed error handling
    public async Task<ApiResult<T>> SafeApiCallAsync<T>(Func<Task<T>> apiCall)
    {
        try
        {
            var result = await apiCall();
            return ApiResult<T>.Success(result);
        }
        catch (ClioApiException ex)
        {
            _logger.LogError(ex, $"Clio API error: {ex.Message}");
            
            return ex.StatusCode switch
            {
                401 => ApiResult<T>.Error("Authentication failed. Please check your API key."),
                403 => ApiResult<T>.Error("Access denied. Insufficient permissions."),
                404 => ApiResult<T>.Error("Resource not found."),
                422 => ApiResult<T>.Error($"Validation failed: {string.Join(", ", ex.Errors ?? new List<string>())}"),
                429 => ApiResult<T>.Error("Rate limit exceeded. Please try again later."),
                _ => ApiResult<T>.Error($"API error: {ex.Message}")
            };
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Network error occurred");
            return ApiResult<T>.Error("Network error. Please check your connection.");
        }
        catch (TaskCanceledException ex)
        {
            _logger.LogError(ex, "Request timed out");
            return ApiResult<T>.Error("Request timed out. Please try again.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Unexpected error occurred");
            return ApiResult<T>.Error("An unexpected error occurred.");
        }
    }
    
    // Example usage
    public async Task<ApiResult<Matter>> CreateMatterSafelyAsync(MatterRequest request)
    {
        return await SafeApiCallAsync(async () =>
        {
            var response = await ExecuteWithRetryAsync(() => _clio.Matters.CreateAsync(request));
            return response.Data;
        });
    }
}

// Result wrapper for safe API calls
public class ApiResult<T>
{
    public bool Success { get; private set; }
    public T? Data { get; private set; }
    public string? ErrorMessage { get; private set; }
    
    public static ApiResult<T> Success(T data) => new() { Success = true, Data = data };
    public static ApiResult<T> Error(string message) => new() { Success = false, ErrorMessage = message };
}
```

---

## Batch Operations

### Bulk Operations with Progress Tracking
```csharp
public class BatchService
{
    private readonly ClioClient _clio;
    private readonly ILogger _logger;
    
    public BatchService(ClioClient clio, ILogger logger)
    {
        _clio = clio;
        _logger = logger;
    }
    
    // Create multiple activities
    public async Task<BatchResult<Activity>> CreateActivitiesAsync(
        List<ActivityRequest> activities,
        IProgress<BatchProgress> progress = null)
    {
        var results = new BatchResult<Activity>();
        var total = activities.Count;
        var processed = 0;
        
        foreach (var activity in activities)
        {
            try
            {
                var response = await _clio.Activities.CreateAsync(activity);
                results.Successes.Add(response.Data);
                
                _logger.LogInformation($"Created activity: {response.Data.Description}");
            }
            catch (Exception ex)
            {
                results.Failures.Add(new BatchError
                {
                    Item = activity,
                    Error = ex.Message
                });
                
                _logger.LogError(ex, $"Failed to create activity: {activity.Description}");
            }
            
            processed++;
            progress?.Report(new BatchProgress
            {
                Processed = processed,
                Total = total,
                Percentage = (int)((double)processed / total * 100)
            });
            
            // Rate limiting protection
            await Task.Delay(100);
        }
        
        return results;
    }
    
    // Update multiple matter statuses
    public async Task<BatchResult<Matter>> UpdateMatterStatusesAsync(
        Dictionary<int, string> matterUpdates,
        IProgress<BatchProgress> progress = null)
    {
        var results = new BatchResult<Matter>();
        var total = matterUpdates.Count;
        var processed = 0;
        
        foreach (var (matterId, newStatus) in matterUpdates)
        {
            try
            {
                var updateRequest = new MatterRequest { Status = newStatus };
                var response = await _clio.Matters.UpdateAsync(matterId, updateRequest);
                results.Successes.Add(response.Data);
                
                _logger.LogInformation($"Updated matter {matterId} to status: {newStatus}");
            }
            catch (Exception ex)
            {
                results.Failures.Add(new BatchError
                {
                    Item = $"Matter {matterId}",
                    Error = ex.Message
                });
                
                _logger.LogError(ex, $"Failed to update matter {matterId}");
            }
            
            processed++;
            progress?.Report(new BatchProgress
            {
                Processed = processed,
                Total = total,
                Percentage = (int)((double)processed / total * 100)
            });
            
            await Task.Delay(100);
        }
        
        return results;
    }
    
    // Archive old matters
    public async Task<BatchResult<Matter>> ArchiveOldMattersAsync(
        DateTime cutoffDate,
        IProgress<BatchProgress> progress = null)
    {
        // Get matters older than cutoff date
        var options = new QueryOptions
        {
            QueryParams = new Dictionary<string, object>
            {
                ["open_date[lte]"] = cutoffDate.ToString("yyyy-MM-dd"),
                ["status"] = "Open"
            }
        };
        
        var mattersResponse = await _clio.Matters.GetAsync(options);
        var matterUpdates = mattersResponse.Data
            .ToDictionary(m => m.Id, _ => "Closed");
        
        return await UpdateMatterStatusesAsync(matterUpdates, progress);
    }
}

// Supporting classes
public class BatchResult<T>
{
    public List<T> Successes { get; set; } = new();
    public List<BatchError> Failures { get; set; } = new();
    
    public bool HasFailures => Failures.Any();
    public int TotalCount => Successes.Count + Failures.Count;
    public int SuccessCount => Successes.Count;
    public int FailureCount => Failures.Count;
}

public class BatchError
{
    public object Item { get; set; }
    public string Error { get; set; }
}

public class BatchProgress
{
    public int Processed { get; set; }
    public int Total { get; set; }
    public int Percentage { get; set; }
}
```

---

## Reporting

### Generate Various Reports
```csharp
public class ReportingService
{
    private readonly ClioClient _clio;
    
    public ReportingService(ClioClient clio)
    {
        _clio = clio;
    }
    
    // Generate time tracking report
    public async Task<TimeTrackingReport> GenerateTimeTrackingReportAsync(
        DateTime startDate, 
        DateTime endDate,
        int? userId = null,
        int? matterId = null)
    {
        var queryParams = new Dictionary<string, object>
        {
            ["date[gte]"] = startDate.ToString("yyyy-MM-dd"),
            ["date[lte]"] = endDate.ToString("yyyy-MM-dd"),
            ["type"] = "TimeEntry"
        };
        
        if (userId.HasValue)
            queryParams["user_id"] = userId.Value;
        
        if (matterId.HasValue)
            queryParams["matter_id"] = matterId.Value;
        
        var activitiesResponse = await _clio.Activities.GetAsync(new QueryOptions
        {
            QueryParams = queryParams,
            OrderBy = "date DESC"
        });
        
        var activities = activitiesResponse.Data;
        
        return new TimeTrackingReport
        {
            StartDate = startDate,
            EndDate = endDate,
            TotalHours = activities.Sum(a => a.Quantity),
            BillableHours = activities.Where(a => a.Billable).Sum(a => a.Quantity),
            NonBillableHours = activities.Where(a => !a.Billable).Sum(a => a.Quantity),
            TotalValue = activities.Where(a => a.Billable).Sum(a => a.Quantity * (a.Price ?? 0)),
            Activities = activities,
            ByMatter = activities.GroupBy(a => a.Matter?.Id)
                               .ToDictionary(g => g.Key, g => g.ToList()),
            ByUser = activities.GroupBy(a => a.User?.Id)
                             .ToDictionary(g => g.Key, g => g.ToList())
        };
    }
    
    // Generate matter performance report
    public async Task<MatterPerformanceReport> GenerateMatterPerformanceReportAsync(
        int matterId)
    {
        var matterResponse = await _clio.Matters.GetAsync(matterId);
        var matter = matterResponse.Data;
        
        // Get activities
        var activitiesResponse = await _clio.Activities.GetAsync(new QueryOptions
        {
            QueryParams = new Dictionary<string, object>
            {
                ["matter_id"] = matterId,
                ["type"] = "TimeEntry"
            }
        });
        
        // Get bills
        var billsResponse = await _clio.Bills.GetAsync(new QueryOptions
        {
            QueryParams = new Dictionary<string, object>
            {
                ["matter_id"] = matterId
            }
        });
        
        var activities = activitiesResponse.Data;
        var bills = billsResponse.Data;
        
        return new MatterPerformanceReport
        {
            Matter = matter,
            TotalHoursWorked = activities.Sum(a => a.Quantity),
            TotalBilled = bills.Where(b => b.Status == "Sent").Sum(b => b.Total),
            TotalPaid = bills.Sum(b => b.Paid),
            BalanceOutstanding = bills.Sum(b => b.Total) - bills.Sum(b => b.Paid),
            ActivityCount = activities.Count,
            BillCount = bills.Count,
            AverageBillValue = bills.Any() ? bills.Average(b => b.Total) : 0,
            RecentActivity = activities.OrderByDescending(a => a.Date).Take(10).ToList(),
            RecentBills = bills.OrderByDescending(b => b.IssueDate).Take(5).ToList()
        };
    }
    
    // Generate client aging report
    public async Task<ClientAgingReport> GenerateClientAgingReportAsync()
    {
        var balancesResponse = await _clio.OutstandingClientBalances.GetAsync();
        var balances = balancesResponse.Data.Where(b => b.Balance > 0).ToList();
        
        var now = DateTime.UtcNow;
        
        return new ClientAgingReport
        {
            GeneratedAt = now,
            TotalOutstanding = balances.Sum(b => b.Balance),
            ClientCount = balances.Count,
            CurrentBalance = balances.Where(b => (now - b.DueDate).Days <= 0).Sum(b => b.Balance),
            Days1to30 = balances.Where(b => (now - b.DueDate).Days > 0 && (now - b.DueDate).Days <= 30).Sum(b => b.Balance),
            Days31to60 = balances.Where(b => (now - b.DueDate).Days > 30 && (now - b.DueDate).Days <= 60).Sum(b => b.Balance),
            Days61to90 = balances.Where(b => (now - b.DueDate).Days > 60 && (now - b.DueDate).Days <= 90).Sum(b => b.Balance),
            Over90Days = balances.Where(b => (now - b.DueDate).Days > 90).Sum(b => b.Balance),
            ClientBalances = balances.OrderByDescending(b => b.Balance).ToList()
        };
    }
}

// Report models
public class TimeTrackingReport
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal TotalHours { get; set; }
    public decimal BillableHours { get; set; }
    public decimal NonBillableHours { get; set; }
    public decimal TotalValue { get; set; }
    public List<Activity> Activities { get; set; }
    public Dictionary<int?, List<Activity>> ByMatter { get; set; }
    public Dictionary<int?, List<Activity>> ByUser { get; set; }
}

public class MatterPerformanceReport
{
    public Matter Matter { get; set; }
    public decimal TotalHoursWorked { get; set; }
    public decimal TotalBilled { get; set; }
    public decimal TotalPaid { get; set; }
    public decimal BalanceOutstanding { get; set; }
    public int ActivityCount { get; set; }
    public int BillCount { get; set; }
    public decimal AverageBillValue { get; set; }
    public List<Activity> RecentActivity { get; set; }
    public List<Bill> RecentBills { get; set; }
}

public class ClientAgingReport
{
    public DateTime GeneratedAt { get; set; }
    public decimal TotalOutstanding { get; set; }
    public int ClientCount { get; set; }
    public decimal CurrentBalance { get; set; }
    public decimal Days1to30 { get; set; }
    public decimal Days31to60 { get; set; }
    public decimal Days61to90 { get; set; }
    public decimal Over90Days { get; set; }
    public List<OutstandingClientBalance> ClientBalances { get; set; }
}
```

---

## Complete Application Example

### ASP.NET Core Web API Integration
```csharp
// Program.cs
var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register Clio SDK
var clioApiKey = builder.Configuration["Clio:ApiKey"];
var clioBaseUrl = builder.Configuration["Clio:BaseUrl"];
builder.Services.AddSingleton(new ClioClient(clioApiKey, clioBaseUrl));

// Register custom services
builder.Services.AddScoped<MatterService>();
builder.Services.AddScoped<TimeTrackingService>();
builder.Services.AddScoped<BillingService>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

// Controllers/MattersController.cs
[ApiController]
[Route("api/[controller]")]
public class MattersController : ControllerBase
{
    private readonly MatterService _matterService;
    
    public MattersController(MatterService matterService)
    {
        _matterService = matterService;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Matter>>> GetMatters([FromQuery] MatterFilter filter)
    {
        try
        {
            var matters = await _matterService.GetFilteredMattersAsync(filter);
            return Ok(matters);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<Matter>> GetMatter(int id)
    {
        try
        {
            var matter = await _matterService.GetMatterByIdAsync(id);
            if (matter == null)
                return NotFound();
            
            return Ok(matter);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    
    [HttpPost]
    public async Task<ActionResult<Matter>> CreateMatter([FromBody] MatterRequest request)
    {
        try
        {
            var result = await _matterService.CreateMatterSafelyAsync(request);
            
            if (!result.Success)
                return BadRequest(result.ErrorMessage);
            
            return CreatedAtAction(nameof(GetMatter), new { id = result.Data.Id }, result.Data);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}
```

These examples demonstrate real-world usage patterns and best practices for integrating the Clio SDK into your applications. Each example includes proper error handling, logging, and follows .NET development best practices.