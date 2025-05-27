using HotChocolate.Types.Pagination;
using HotChocolate.Data;
using Quinn.SampleGQL.Infrastructure;
using Quinn.SampleGQL.Models;

namespace Quinn.SampleGQL.Application;

public class RandomQuery(IApplicationDatabase applicationDatabase)
{
    
    [UsePaging(IncludeTotalCount = true)]
    [UseSorting]
    public IQueryable<ClientData> GetClients()
    {
        return applicationDatabase.GetClients()
            .AsQueryable();
    }
}