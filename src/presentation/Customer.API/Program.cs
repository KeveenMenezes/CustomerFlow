using CustomerFlow.BuildingBlocks.ServiceDefaults;
using CustomerFlow.BuildingBlocks.ServiceDefaults.Handlers;
using CustomerFlow.Core.Application.Configuration;
using CustomerFlow.Infra.CommandRepository.Configuration;
using CustomerFlow.Infra.CustomerIntegrationAdapter.Configuration;
using CustomerFlow.Presentation.API.Endpoints.Customers;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.AddServiceDefaults();
builder.Services.AddEndpointsApiExplorer();

builder.Services
    .AddOpenApi()
    .AddExceptionHandler<CustomExceptionHandler>()
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddCustomerIntegrationAdapterServices();

var app = builder.Build();
// Configure the HTTP request pipeline.

app.MapDefaultEndpoints();
app.MapEndpoint();
app.UseExceptionHandler(options => { });
app.MapOpenApi();
app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });

await app.RunAsync();
