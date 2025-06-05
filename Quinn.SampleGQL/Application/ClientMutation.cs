using HotChocolate.Authorization;
using Quinn.SampleGQL.Infrastructure;
using Quinn.SampleGQL.Models;

namespace Quinn.SampleGQL.Application;

public class ClientMutation(IApplicationDatabase applicationDatabase)
{
    [Authorize]
    public ClientData CreateClient(CreateClientDataInput input)
    {
        return applicationDatabase.AddClient(input);
    }

    [Authorize]
    public ClientData? UpdateClient(UpdateClientDataInput input)
    {
        return applicationDatabase.UpdateClient(input);
    }
} 