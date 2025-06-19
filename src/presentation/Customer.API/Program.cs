var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseHttpsRedirection();
await app.RunAsync();
