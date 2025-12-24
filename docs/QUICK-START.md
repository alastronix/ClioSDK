# Clio SDK Quick Start Guide

This guide will get you up and running with the Clio SDK in minutes.

## Prerequisites

- .NET 9.0 or higher
- Visual Studio 2022 or VS Code
- Clio API access and API key

## Step 1: Installation

### Using NuGet Package Manager
```bash
dotnet add package ClioSDK
```

### Using Package Manager Console
```powershell
Install-Package ClioSDK
```

### Using .NET CLI
```bash
dotnet add package ClioSDK
```

## Step 2: Get Your API Key

1. Log into your Clio account
2. Go to Settings → API Management
3. Generate a new API key
4. Copy the API key for use in your application

## Step 3: Basic Setup

### Create a Console Application
```bash
dotnet new console -n ClioDemo
cd ClioDemo
dotnet add package ClioSDK
```

### Add Using Statement
```csharp
using ClioSDK;
```

### Initialize the Client
```csharp
var apiKey = "your-clio-api-key";
var clio = new ClioClient(apiKey);
```

## Step 4: First API Call

### Simple Console Application
```csharp
using ClioSDK;

class Program
{
    static async Task Main(string[] args)
    {
        // Initialize client
        var apiKey = "your-clio-api-key";
        var clio = new ClioClient(apiKey);
        
        try
        {
            // Get all matters
            var matters = await clio.Matters.GetAsync();
            
            Console.WriteLine($"Found {matters.Data.Count} matters:");
            
            foreach (var matter in matters.Data)
            {
                Console.WriteLine($"- {matter.Id}: {matter.Description} ({matter.Status})");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
```

## Step 5: Common Operations

### Working with Matters
```csharp
// Get all matters
var matters = await clio.Matters.GetAsync();

// Get specific matter
var matter = await clio.Matters.GetAsync(123);

// Create new matter
var newMatter = new MatterRequest
{
    Description = "New Legal Case",
    Status = "Open",
    Client = new ContactReference { Id = 456 }
};
var created = await clio.Matters.CreateAsync(newMatter);

// Update matter
var updateRequest = new MatterRequest
{
    Description = "Updated Case Description"
};
var updated = await clio.Matters.UpdateAsync(123, updateRequest);
```

### Working with Activities (Time Tracking)
```csharp
// Log time entry
var activity = new ActivityRequest
{
    Description = "Legal research",
    Matter = new MatterReference { Id = 123 },
    Quantity = 2.5m, // 2.5 hours
    Billable = true,
    Date = DateTime.UtcNow
};
var logged = await clio.Activities.CreateAsync(activity);

// Get activities for a specific matter
var options = new QueryOptions
{
    QueryParams = new Dictionary<string, object>
    {
        ["matter_id"] = 123
    }
};
var matterActivities = await clio.Activities.GetAsync(options);
```

### Working with Contacts
```csharp
// Get all contacts
var contacts = await clio.Contacts.GetAsync();

// Create new contact
var newContact = new ContactRequest
{
    Name = "John Doe",
    FirstName = "John",
    LastName = "Doe",
    Type = "Person",
    EmailAddress = "john.doe@example.com"
};
var createdContact = await clio.Contacts.CreateAsync(newContact);
```

### Working with Documents
```csharp
// Get all documents
var documents = await clio.Documents.GetAsync();

// Create document metadata
var document = new DocumentRequest
{
    Name = "Contract.pdf",
    Description = "Client contract",
    Matter = new MatterReference { Id = 123 }
};
var createdDocument = await clio.Documents.CreateAsync(document);
```

## Step 6: Advanced Usage

### Custom Base URL
```csharp
var clio = new ClioClient(
    "your-api-key", 
    "https://your-custom-instance.clio.com/api/v4/"
);
```

### Query Parameters
```csharp
// Get matters with filters
var filteredMatters = await clio.Matters.GetAsync(new QueryOptions
{
    Limit = 50,
    Offset = 0,
    Fields = "id,description,status,client"
});

// Get contacts by type
var clientContacts = await clio.Contacts.GetAsync(new QueryOptions
{
    QueryParams = new Dictionary<string, object>
    {
        ["type"] = "Person"
    }
});
```

### Error Handling
```csharp
try
{
    var matter = await clio.Matters.GetAsync(123);
    // Process matter
}
catch (ClioApiException ex)
{
    // Handle API-specific errors
    Console.WriteLine($"API Error: {ex.Message}");
    Console.WriteLine($"Status Code: {ex.StatusCode}");
    
    if (ex.Errors != null)
    {
        foreach (var error in ex.Errors)
        {
            Console.WriteLine($"Detail: {error}");
        }
    }
}
catch (HttpRequestException ex)
{
    // Handle network errors
    Console.WriteLine($"Network Error: {ex.Message}");
}
```

## Step 7: ASP.NET Core Integration

### Configure Services
```csharp
// In Program.cs
builder.Services.AddSingleton(new ClioClient("your-api-key"));
```

### Use in Controller
```csharp
[ApiController]
[Route("api/[controller]")]
public class MattersController : ControllerBase
{
    private readonly ClioClient _clio;
    
    public MattersController(ClioClient clio)
    {
        _clio = clio;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var matters = await _clio.Matters.GetAsync();
            return Ok(matters.Data);
        }
        catch (ClioApiException ex)
        {
            return StatusCode((int)ex.StatusCode, ex.Message);
        }
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            var matter = await _clio.Matters.GetAsync(id);
            return Ok(matter.Data);
        }
        catch (ClioApiException ex) when (ex.StatusCode == 404)
        {
            return NotFound();
        }
        catch (ClioApiException ex)
        {
            return StatusCode((int)ex.StatusCode, ex.Message);
        }
    }
}
```

## Step 8: Configuration Best Practices

### Use Configuration Files
```json
// appsettings.json
{
  "Clio": {
    "ApiKey": "your-api-key",
    "BaseUrl": "https://app.clio.com/api/v4/"
  }
}
```

### Configure in Startup
```csharp
// Program.cs
var clioConfig = builder.Configuration.GetSection("Clio");
var apiKey = clioConfig["ApiKey"];
var baseUrl = clioConfig["BaseUrl"];

builder.Services.AddSingleton(new ClioClient(apiKey, baseUrl));
```

### Use Environment Variables
```csharp
var apiKey = Environment.GetEnvironmentVariable("CLIO_API_KEY");
var clio = new ClioClient(apiKey);
```

## Step 9: Testing

### Unit Testing with Mocks
```csharp
using Moq;
using Xunit;
using Microsoft.Extensions.Http;

public class MatterServiceTests
{
    [Fact]
    public async Task GetMatters_ReturnsMatterList()
    {
        // Arrange
        var mockClient = new Mock<ClioClient>();
        mockClient.Setup(x => x.Matters.GetAsync())
                 .ReturnsAsync(new PaginatedResponse<Matter>
                 {
                     Data = new List<Matter>
                     {
                         new Matter { Id = 1, Description = "Test Matter" }
                     }
                 });
        
        var service = new MatterService(mockClient.Object);
        
        // Act
        var result = await service.GetAllMatters();
        
        // Assert
        Assert.Single(result);
        Assert.Equal("Test Matter", result.First().Description);
    }
}
```

## Step 10: Common Patterns

### Repository Pattern
```csharp
public interface IMatterRepository
{
    Task<IEnumerable<Matter>> GetAllAsync();
    Task<Matter?> GetByIdAsync(int id);
    Task<Matter> CreateAsync(MatterRequest request);
}

public class MatterRepository : IMatterRepository
{
    private readonly ClioClient _clio;
    
    public MatterRepository(ClioClient clio)
    {
        _clio = clio;
    }
    
    public async Task<IEnumerable<Matter>> GetAllAsync()
    {
        var response = await _clio.Matters.GetAsync();
        return response.Data;
    }
    
    public async Task<Matter?> GetByIdAsync(int id)
    {
        try
        {
            var response = await _clio.Matters.GetAsync(id);
            return response.Data;
        }
        catch (ClioApiException ex) when (ex.StatusCode == 404)
        {
            return null;
        }
    }
    
    public async Task<Matter> CreateAsync(MatterRequest request)
    {
        var response = await _clio.Matters.CreateAsync(request);
        return response.Data;
    }
}
```

### Service Layer
```csharp
public class MatterService
{
    private readonly IMatterRepository _repository;
    
    public MatterService(IMatterRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<Matter>> GetAllOpenMattersAsync()
    {
        var allMatters = await _repository.GetAllAsync();
        return allMatters.Where(m => m.Status == "Open");
    }
    
    public async Task<Matter> CreateMatterAsync(MatterRequest request)
    {
        // Business logic validation
        if (string.IsNullOrWhiteSpace(request.Description))
        {
            throw new ArgumentException("Matter description is required");
        }
        
        return await _repository.CreateAsync(request);
    }
}
```

## Troubleshooting

### Common Issues

1. **API Key Not Working**
   - Verify API key is correct
   - Check if key has required permissions
   - Ensure you're using the correct environment (production vs sandbox)

2. **401 Unauthorized**
   - API key is invalid or expired
   - Missing or incorrect authentication header

3. **403 Forbidden**
   - API key doesn't have permission for the requested resource
   - User doesn't have access to the specific matter/contact

4. **Rate Limiting (429)**
   - Implement exponential backoff
   - Cache frequently accessed data
   - Use pagination for large datasets

### Debugging Tips

```csharp
// Enable detailed logging
var httpClient = new HttpClient(new HttpLoggingHandler(new HttpClientHandler()));
var clio = new ClioClient("your-api-key", httpClient);

// Add logging
public class HttpLoggingHandler : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Request: {request.Method} {request.RequestUri}");
        
        var response = await base.SendAsync(request, cancellationToken);
        
        Console.WriteLine($"Response: {(int)response.StatusCode} {response.ReasonPhrase}");
        
        return response;
    }
}
```

## Next Steps

- Explore the full [API Reference](./API-REFERENCE.md)
- Check out more [Examples](./EXAMPLES.md)
- Learn about [Testing](./TESTING.md)
- Review [Best Practices](./BEST-PRACTICES.md)

## Support

- [Clio API Documentation](https://developers.clio.com/)
- [SDK Repository](https://github.com/alastronix/ClioSDK.git)
- [Issues](https://github.com/alastronix/ClioSDK/issues)

Happy coding! 🚀