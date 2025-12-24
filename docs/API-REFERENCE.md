# Clio SDK API Reference

This document provides detailed API reference for all client classes and their methods.

## Base Client Methods

All client classes inherit from `BaseClient` and provide the following standard methods:

### HTTP Methods
- `GetAsync()` - Retrieve all resources
- `GetAsync(int id)` - Retrieve specific resource by ID
- `CreateAsync(TRequest request)` - Create new resource
- `UpdateAsync(int id, TRequest request)` - Update existing resource
- `DeleteAsync(int id)` - Delete resource

### Query Options
- `QueryOptions` - Parameter object for filtering and pagination
- `QueryParams` - Dictionary for custom query parameters

---

## Core Business Operations

### ActivitiesClient

**Purpose**: Manage time tracking and activities

**Methods**:
```csharp
// Get all activities
Task<PaginatedResponse<Activity>> GetAsync(QueryOptions? options = null)

// Get specific activity
Task<ApiResponse<Activity>> GetAsync(int id, QueryOptions? options = null)

// Create new activity
Task<ApiResponse<Activity>> CreateAsync(ActivityRequest request)

// Update activity
Task<ApiResponse<Activity>> UpdateAsync(int id, ActivityRequest request)

// Delete activity
Task<bool> DeleteAsync(int id)
```

**ActivityRequest Properties**:
- `Description` (string) - Activity description
- `Matter` (MatterReference) - Associated matter
- `Quantity` (decimal) - Time quantity
- `Billable` (bool) - Whether billable
- `Date` (DateTime) - Activity date
- `User` (UserReference) - User who performed activity

### MattersClient

**Purpose**: Manage legal matters and cases

**Methods**:
```csharp
// Get all matters
Task<PaginatedResponse<Matter>> GetAsync(QueryOptions? options = null)

// Get specific matter
Task<ApiResponse<Matter>> GetAsync(int id, QueryOptions? options = null)

// Create new matter
Task<ApiResponse<Matter>> CreateAsync(MatterRequest request)

// Update matter
Task<ApiResponse<Matter>> UpdateAsync(int id, MatterRequest request)

// Delete matter
Task<bool> DeleteAsync(int id)
```

**MatterRequest Properties**:
- `Description` (string) - Matter description
- `Status` (string) - Matter status
- `Client` (ContactReference) - Associated client
- `PracticeArea` (PracticeAreaReference) - Practice area
- `OpenDate` (DateTime) - Matter open date
- `CloseDate` (DateTime?) - Matter close date
- `BillingMethod` (string) - Billing method

### ContactsClient

**Purpose**: Manage clients and contacts

**Methods**:
```csharp
// Get all contacts
Task<PaginatedResponse<Contact>> GetAsync(QueryOptions? options = null)

// Get specific contact
Task<ApiResponse<Contact>> GetAsync(int id, QueryOptions? options = null)

// Create new contact
Task<ApiResponse<Contact>> CreateAsync(ContactRequest request)

// Update contact
Task<ApiResponse<Contact>> UpdateAsync(int id, ContactRequest request)

// Delete contact
Task<bool> DeleteAsync(int id)
```

**ContactRequest Properties**:
- `Name` (string) - Contact name
- `Type` (string) - Contact type (Person/Organization)
- `FirstName` (string) - First name
- `LastName` (string) - Last name
- `Company` (string) - Company name
- `EmailAddress` (string) - Email address
- `PhoneNumber` (string) - Phone number

### BillsClient

**Purpose**: Manage billing and invoices

**Methods**:
```csharp
// Get all bills
Task<PaginatedResponse<Bill>> GetAsync(QueryOptions? options = null)

// Get specific bill
Task<ApiResponse<Bill>> GetAsync(int id, QueryOptions? options = null)

// Create new bill
Task<ApiResponse<Bill>> CreateAsync(BillRequest request)

// Update bill
Task<ApiResponse<Bill>> UpdateAsync(int id, BillRequest request)

// Delete bill
Task<bool> DeleteAsync(int id)
```

**BillRequest Properties**:
- `Matter` (MatterReference) - Associated matter
- `Client` (ContactReference) - Billed client
- `IssueDate` (DateTime) - Bill issue date
- `DueDate` (DateTime) - Bill due date
- `Total` (decimal) - Bill total
- `Status` (string) - Bill status

---

## Financial & Accounting

### TrustAccountsClient

**Purpose**: Manage trust accounts for client funds

**Methods**:
```csharp
Task<PaginatedResponse<TrustAccount>> GetAsync(QueryOptions? options = null)
Task<ApiResponse<TrustAccount>> GetAsync(int id, QueryOptions? options = null)
Task<ApiResponse<TrustAccount>> CreateAsync(TrustAccountRequest request)
Task<ApiResponse<TrustAccount>> UpdateAsync(int id, TrustAccountRequest request)
Task<bool> DeleteAsync(int id)
```

### BankAccountsClient

**Purpose**: Manage bank accounts

**Methods**:
```csharp
Task<PaginatedResponse<BankAccount>> GetAsync(QueryOptions? options = null)
Task<ApiResponse<BankAccount>> GetAsync(int id, QueryOptions? options = null)
Task<ApiResponse<BankAccount>> CreateAsync(BankAccountRequest request)
Task<ApiResponse<BankAccount>> UpdateAsync(int id, BankAccountRequest request)
Task<bool> DeleteAsync(int id)
```

### LineItemsClient

**Purpose**: Manage bill line items

**Methods**:
```csharp
Task<PaginatedResponse<LineItem>> GetAsync(QueryOptions? options = null)
Task<ApiResponse<LineItem>> GetAsync(int id, QueryOptions? options = null)
Task<ApiResponse<LineItem>> CreateAsync(LineItemRequest request)
Task<ApiResponse<LineItem>> UpdateAsync(int id, LineItemRequest request)
Task<bool> DeleteAsync(int id)
```

---

## Document Management

### DocumentsClient

**Purpose**: Manage documents and files

**Methods**:
```csharp
Task<PaginatedResponse<Document>> GetAsync(QueryOptions? options = null)
Task<ApiResponse<Document>> GetAsync(int id, QueryOptions? options = null)
Task<ApiResponse<Document>> CreateAsync(DocumentRequest request)
Task<ApiResponse<Document>> UpdateAsync(int id, DocumentRequest request)
Task<bool> DeleteAsync(int id)
```

### DocumentVersionsClient

**Purpose**: Manage document versions

**Methods**:
```csharp
Task<PaginatedResponse<DocumentVersion>> GetAsync(QueryOptions? options = null)
Task<ApiResponse<DocumentVersion>> GetAsync(int id, QueryOptions? options = null)
Task<ApiResponse<DocumentVersion>> CreateAsync(DocumentVersionRequest request)
Task<ApiResponse<DocumentVersion>> UpdateAsync(int id, DocumentVersionRequest request)
Task<bool> DeleteAsync(int id)
```

---

## Communication & Relationships

### ConversationsClient

**Purpose**: Manage conversations with clients

**Methods**:
```csharp
Task<PaginatedResponse<Conversation>> GetAsync(QueryOptions? options = null)
Task<ApiResponse<Conversation>> GetAsync(int id, QueryOptions? options = null)
Task<ApiResponse<Conversation>> CreateAsync(ConversationRequest request)
Task<ApiResponse<Conversation>> UpdateAsync(int id, ConversationRequest request)
Task<bool> DeleteAsync(int id)
```

### NotesClient

**Purpose**: Manage notes and annotations

**Methods**:
```csharp
Task<PaginatedResponse<Note>> GetAsync(QueryOptions? options = null)
Task<ApiResponse<Note>> GetAsync(int id, QueryOptions? options = null)
Task<ApiResponse<Note>> CreateAsync(NoteRequest request)
Task<ApiResponse<Note>> UpdateAsync(int id, NoteRequest request)
Task<bool> DeleteAsync(int id)
```

---

## Customization & Configuration

### CustomFieldsClient

**Purpose**: Manage custom field definitions

**Methods**:
```csharp
Task<PaginatedResponse<CustomField>> GetAsync(QueryOptions? options = null)
Task<ApiResponse<CustomField>> GetAsync(int id, QueryOptions? options = null)
Task<ApiResponse<CustomField>> CreateAsync(CustomFieldRequest request)
Task<ApiResponse<CustomField>> UpdateAsync(int id, CustomFieldRequest request)
Task<bool> DeleteAsync(int id)
```

### WebhooksClient

**Purpose**: Manage webhook configurations

**Methods**:
```csharp
Task<PaginatedResponse<Webhook>> GetAsync(QueryOptions? options = null)
Task<ApiResponse<Webhook>> GetAsync(int id, QueryOptions? options = null)
Task<ApiResponse<Webhook>> CreateAsync(WebhookRequest request)
Task<ApiResponse<Webhook>> UpdateAsync(int id, WebhookRequest request)
Task<bool> DeleteAsync(int id)
```

---

## Reference Objects

### MatterReference
```csharp
public class MatterReference
{
    public int Id { get; set; }
}
```

### ContactReference
```csharp
public class ContactReference
{
    public int Id { get; set; }
}
```

### UserReference
```csharp
public class UserReference
{
    public int Id { get; set; }
}
```

### BankAccountReference
```csharp
public class BankAccountReference
{
    public int Id { get; set; }
}
```

---

## Query Options

```csharp
public class QueryOptions
{
    public int? Limit { get; set; } = 50;
    public int? Offset { get; set; } = 0;
    public string? Fields { get; set; }
    public Dictionary<string, object>? QueryParams { get; set; }
}
```

---

## Response Objects

### PaginatedResponse
```csharp
public class PaginatedResponse
{
    public List Data { get; set; }
    public Pagination Pagination { get; set; }
}
```

### ApiResponse
```csharp
public class ApiResponse
{
    public T Data { get; set; }
    public Meta Meta { get; set; }
}
```

---

## Error Handling

The SDK provides comprehensive error handling:

### ClioApiException
```csharp
public class ClioApiException : Exception
{
    public int StatusCode { get; set; }
    public string? ErrorCode { get; set; }
    public List<string>? Errors { get; set; }
}
```

### Common Error Codes
- `400` - Bad Request (invalid parameters)
- `401` - Unauthorized (invalid API key)
- `403` - Forbidden (insufficient permissions)
- `404` - Not Found (resource doesn't exist)
- `422` - Unprocessable Entity (validation errors)
- `429` - Rate Limit Exceeded
- `500` - Internal Server Error

---

## Usage Examples

### Basic CRUD Operations
```csharp
// Create
var matter = await clio.Matters.CreateAsync(new MatterRequest
{
    Description = "New Case",
    Client = new ContactReference { Id = 123 }
});

// Read
var matters = await clio.Matters.GetAsync();
var specificMatter = await clio.Matters.GetAsync(matter.Data.Id);

// Update
await clio.Matters.UpdateAsync(matter.Data.Id, new MatterRequest
{
    Description = "Updated Case Description"
});

// Delete
await clio.Matters.DeleteAsync(matter.Data.Id);
```

### Advanced Filtering
```csharp
var options = new QueryOptions
{
    Limit = 100,
    Offset = 0,
    Fields = "id,description,status,client",
    QueryParams = new Dictionary<string, object>
    {
        ["status"] = "Open",
        ["client_id"] = 123
    }
};

var filteredMatters = await clio.Matters.GetAsync(options);
```

### Error Handling
```csharp
try
{
    var matter = await clio.Matters.GetAsync(123);
}
catch (ClioApiException ex)
{
    Console.WriteLine($"API Error: {ex.Message}");
    Console.WriteLine($"Status: {ex.StatusCode}");
    
    foreach (var error in ex.Errors ?? new List<string>())
    {
        Console.WriteLine($"Error: {error}");
    }
}
```