using CsvHandler.Application.Extensions;
using CsvHandler.Core.RepositoryContracts;
using CsvHandler.Infrastructure.Extensions;
using CsvHandler.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddApplication();


builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();