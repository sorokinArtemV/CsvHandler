﻿using CsvHandler.Core.RepositoryContracts;
using CsvHandler.Infrastructure.DatabaseContext;
using CsvHandler.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CsvHandler.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection builder, IConfiguration config)
    {
        builder.AddDbContext<UsersDbContext>(opts =>
        {
            opts.UseNpgsql(config.GetConnectionString("DefaultConnection"));
        });

        builder.AddScoped<IUsersRepository, UsersRepository>();
    }
}