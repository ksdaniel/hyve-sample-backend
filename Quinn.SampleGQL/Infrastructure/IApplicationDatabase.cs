using Quinn.SampleGQL.Models;

namespace Quinn.SampleGQL.Infrastructure;

public interface IApplicationDatabase
{
    public IQueryable<ClientData> GetClients();
}