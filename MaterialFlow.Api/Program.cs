using MaterialFlow.Api.Extensions;
using MaterialFlow.Application;
using MaterialFlow.Infrastructure;
using MaterialFlow.Presentation.Endpoints;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddEndpoints(typeof(IEndpoint).Assembly);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();

    app.MapGet("/", () => Results.Redirect("/scalar/v1"))
        .ExcludeFromDescription();

    app.ApplyMigrations();
}

app.UseHttpsRedirection();
app.MapEndpoints();

app.Run();
