using HotChocolate.Authorization;
using HotChocolate.Types.Pagination;
using HotChocolate.Data;
using Quinn.SampleGQL.Infrastructure;
using Quinn.SampleGQL.Models;

namespace Quinn.SampleGQL.Application;

public class RandomQuery(IApplicationDatabase applicationDatabase)
{
    [Authorize]
    [UsePaging(IncludeTotalCount = true)]
    [UseSorting]
    public IQueryable<ClientData> GetClients()
    {
        return applicationDatabase.GetClients()
            .AsQueryable();
    }
    
    [Authorize]
    public ClientData? GetClientById(string id)
    {
        return applicationDatabase.GetClients()
            .FirstOrDefault(c => c.Id == id);
    }
}