using Quinn.SampleGQL.Application;
using Quinn.SampleGQL.Infrastructure;
using HotChocolate.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var authority = builder.Configuration.GetSection("Authentication").GetValue("Authority", string.Empty);
var validAudience = builder.Configuration.GetSection("Authentication").GetValue("ValidAudience", string.Empty);

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = authority;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidAudience = validAudience,
            ValidateIssuer = true,
            ValidIssuer = authority,
            ValidAudiences = ["profile"]
        };
        options.Events = new JwtBearerEvents()
        {
            OnAuthenticationFailed = context =>
            {
                Console.WriteLine("OnAuthenticationFailed");
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddAuthorization();

builder.Services
    .AddGraphQLServer()
    .ModifyOptions(o =>
    {
        o.EnableDirectiveIntrospection = true;
    })
    .ModifyRequestOptions(o =>
    {
        o.IncludeExceptionDetails = true;
    })
    .AddAuthorization()
    .AddQueryType<RandomQuery>()
    .AddMutationType<ClientMutation>()
    .AddFiltering()
    .AddSorting();

builder.Services.AddSingleton<IApplicationDatabase, ApplicationDatabase>();

var app = builder.Build();

app.MapGraphQL();

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

// Add endpoints for GraphQL

app.Run();
