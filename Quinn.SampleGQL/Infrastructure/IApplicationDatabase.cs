using Quinn.SampleGQL.Models;

namespace Quinn.SampleGQL.Infrastructure;

public interface IApplicationDatabase
{
    public IQueryable<ClientData> GetClients();
    public ClientData AddClient(CreateClientDataInput input);
    public ClientData? UpdateClient(UpdateClientDataInput input);
}