using Quinn.SampleGQL.Models;
using Bogus;

namespace Quinn.SampleGQL.Infrastructure;

public class ApplicationDatabase : IApplicationDatabase
{
    
    private readonly IConfiguration _configuration;
    
    private List<ClientData> _clients = new List<ClientData>();

    public ApplicationDatabase(IConfiguration configuration)
    {
        _configuration = configuration;
        // Initialize the database with clients
        var numberOfClients = _configuration.GetValue<int>("NumberOfClients", 1000);

        _clients = Enumerable.Range(1, numberOfClients)
            .Select(_ => GetRandomClient())
            .ToList();
    }

    public IQueryable<ClientData> GetClients()
    {
        return _clients.AsQueryable();
    }

    public ClientData AddClient(CreateClientDataInput input)
    {
        var newClient = new ClientData
        {
            Id = Guid.NewGuid().ToString(),
            Name = input.Name,
            InvestableAssets = input.InvestableAssets,
            Aum = input.Aum,
            Salary = input.Salary,
            DateOnboarded = input.DateOnboarded ?? DateTime.Now.ToString("yyyy-MM-dd"),
            Status = input.Status,
            Summary = input.Summary,
            Phone = input.Phone,
            Email = input.Email,
            Priority = input.Priority,
            DateOfBirth = input.DateOfBirth,
            Address = input.Address,
            Prospect = input.Prospect,
            Unread = input.Unread
        };

        _clients.Add(newClient);
        return newClient;
    }

    public ClientData? UpdateClient(UpdateClientDataInput input)
    {
        var existingClient = _clients.FirstOrDefault(c => c.Id == input.Id);
        if (existingClient == null)
            return null;

        // Only update fields that are provided (not null)
        if (input.Name != null)
            existingClient.Name = input.Name;
        if (input.InvestableAssets.HasValue)
            existingClient.InvestableAssets = input.InvestableAssets.Value;
        if (input.Aum.HasValue)
            existingClient.Aum = input.Aum;
        if (input.Salary.HasValue)
            existingClient.Salary = input.Salary.Value;
        if (input.DateOnboarded != null)
            existingClient.DateOnboarded = input.DateOnboarded;
        if (input.Status.HasValue)
            existingClient.Status = input.Status.Value;
        if (input.Summary != null)
            existingClient.Summary = input.Summary;
        if (input.Phone != null)
            existingClient.Phone = input.Phone;
        if (input.Email != null)
            existingClient.Email = input.Email;
        if (input.Priority.HasValue)
            existingClient.Priority = input.Priority;
        if (input.DateOfBirth != null)
            existingClient.DateOfBirth = input.DateOfBirth;
        if (input.Address != null)
            existingClient.Address = input.Address;
        if (input.Prospect != null)
            existingClient.Prospect = input.Prospect;
        if (input.Unread.HasValue)
            existingClient.Unread = input.Unread;

        return existingClient;
    }

    private ClientData GetRandomClient() => new Faker<ClientData>()
        .RuleFor(c => c.Id, f => f.Random.Guid().ToString())
        .RuleFor(c => c.Name, f => f.Name.FullName())
        .RuleFor(c => c.InvestableAssets, f => f.Random.Int(10000, 1000000))
        .RuleFor(c => c.Aum, f => f.Random.Int(5000, 5000000))
        .RuleFor(c => c.Salary, f => f.Random.Int(30000, 200000))
        .RuleFor(c => c.DateOnboarded, f => f.Date.Past(5).ToString("yyyy-MM-dd"))
        .RuleFor(c => c.Status, f => f.PickRandom<ClientStatus>())
        .RuleFor(c => c.Summary, f => f.Lorem.Sentence())
        .RuleFor(c => c.Phone, f => f.Phone.PhoneNumber())
        .RuleFor(c => c.Email, (f, c) => $"{c.Name.ToLower().Replace(" ", ".")}@example.com")
        .RuleFor(c => c.Priority, f => f.Random.Bool())
        .RuleFor(c => c.DateOfBirth, f => f.Date.Past(30).ToString("yyyy-MM-dd"))
        .RuleFor(c => c.Address, f => $"{f.Address.StreetAddress()}, {f.Address.City()}, {f.Address.State()} {f.Address.ZipCode()}")
        .RuleFor(c => c.Prospect, (f, c) => $"{c.Name} Prospect")
        .RuleFor(c => c.Unread, f => f.Random.Bool());

}