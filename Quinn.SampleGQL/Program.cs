using Quinn.SampleGQL.Application;
using Quinn.SampleGQL.Infrastructure;
using HotChocolate.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://cognito-idp.eu-north-1.amazonaws.com/eu-north-1_C1yJIPZCf";
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidAudience = "79nm6197p91uq3ja860s4rsq3i",
            ValidateIssuer = true,
            ValidIssuer = $"https://cognito-idp.eu-north-1.amazonaws.com/eu-north-1_C1yJIPZCf",
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
    .AddAuthorization()
    .AddQueryType<RandomQuery>()
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
