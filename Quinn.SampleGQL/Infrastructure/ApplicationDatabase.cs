using Quinn.SampleGQL.Models;
using Bogus;

namespace Quinn.SampleGQL.Infrastructure;

public class ApplicationDatabase : IApplicationDatabase
{
    public IQueryable<ClientData> GetClients()
    {
        return Enumerable.Range(1, 1000)
            .Select(_ => GetRandomClient())
            .AsQueryable();
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