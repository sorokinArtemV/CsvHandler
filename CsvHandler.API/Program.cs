using CsvHandler.Application.Extensions;
using CsvHandler.Core.RepositoryContracts;
using CsvHandler.Infrastructure.Extensions;
using CsvHandler.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddApplication();

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();