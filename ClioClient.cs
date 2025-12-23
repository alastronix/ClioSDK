using ClioSDK.Clients;
using ClioSDK.Core;

namespace ClioSDK;

public class ClioClient : IDisposable
{
    private readonly HttpClient _httpClient;
    private bool _disposed = false;

    public ActivitiesClient Activities { get; }
    public MattersClient Matters { get; }
    public ContactsClient Contacts { get; }
    public BillsClient Bills { get; }
    public DocumentsClient Documents { get; }
    public UsersClient Users { get; }
    public TasksClient Tasks { get; }
    public CalendarsClient Calendars { get; }
    public TrustAccountsClient TrustAccounts { get; }
    public CustomFieldsClient CustomFields { get; }
    public NotesClient Notes { get; }
    public TimersClient Timers { get; }
    public GroupsClient Groups { get; }
    public WebhooksClient Webhooks { get; }
    public BankAccountsClient BankAccounts { get; }
    public BankTransactionsClient BankTransactions { get; }
    public CalendarEntriesClient CalendarEntries { get; }
    public ExpenseCategoriesClient ExpenseCategories { get; }
    public LineItemsClient LineItems { get; }
    public RelationshipsClient Relationships { get; }
    public PracticeAreasClient PracticeAreas { get; }
    public TextSnippetsClient TextSnippets { get; }
    public ClioPaymentsLinksClient ClioPaymentsLinks { get; }
    public ImportConfigurationsClient ImportConfigurations { get; }

    public ClioClient(string apiKey, HttpClient? httpClient = null)
    {
        _httpClient = httpClient ?? new HttpClient();
        _httpClient.BaseAddress = new Uri("https://app.clio.com/api/v4/");
        _httpClient.DefaultRequestHeaders.Authorization = 
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

        // Initialize all clients
        Activities = new ActivitiesClient(_httpClient);
        Matters = new MattersClient(_httpClient);
        Contacts = new ContactsClient(_httpClient);
        Bills = new BillsClient(_httpClient);
        Documents = new DocumentsClient(_httpClient);
        Users = new UsersClient(_httpClient);
        Tasks = new TasksClient(_httpClient);
        Calendars = new CalendarsClient(_httpClient);
        TrustAccounts = new TrustAccountsClient(_httpClient);
        CustomFields = new CustomFieldsClient(_httpClient);
        Notes = new NotesClient(_httpClient);
        Timers = new TimersClient(_httpClient);
        Groups = new GroupsClient(_httpClient);
        Webhooks = new WebhooksClient(_httpClient);
    }

    public ClioClient(string apiKey, string baseUrl, HttpClient? httpClient = null)
    {
        _httpClient = httpClient ?? new HttpClient();
        _httpClient.BaseAddress = new Uri(baseUrl);
        _httpClient.DefaultRequestHeaders.Authorization = 
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

        // Initialize all clients
        Activities = new ActivitiesClient(_httpClient);
        Matters = new MattersClient(_httpClient);
        Contacts = new ContactsClient(_httpClient);
        Bills = new BillsClient(_httpClient);
        Documents = new DocumentsClient(_httpClient);
        Users = new UsersClient(_httpClient);
        Tasks = new TasksClient(_httpClient);
        Calendars = new CalendarsClient(_httpClient);
        TrustAccounts = new TrustAccountsClient(_httpClient);
        CustomFields = new CustomFieldsClient(_httpClient);
        Notes = new NotesClient(_httpClient);
        Timers = new TimersClient(_httpClient);
        Groups = new GroupsClient(_httpClient);
        Webhooks = new WebhooksClient(_httpClient);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
        {
            _httpClient?.Dispose();
            _disposed = true;
        }
    }
}