using Quinn.SampleGQL.Application;
using Quinn.SampleGQL.Infrastructure;
using HotChocolate.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<RandomQuery>()
    .AddFiltering()
    .AddSorting();

builder.Services.AddSingleton<IApplicationDatabase, ApplicationDatabase>();

var app = builder.Build();

app.MapGraphQL();

app.UseHttpsRedirection();

// Add endpoints for GraphQL

app.Run();
