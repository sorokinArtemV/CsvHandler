using CsvHandler.Application.helpers;
using CsvHandler.Application.Services;
using CsvHandler.Core.ServiceContracts;
using CsvHandler.Core.Users.DTO;
using Microsoft.Extensions.DependencyInjection;

namespace CsvHandler.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(UserProfile));
        services.AddScoped<IUserUploadService, UserUploadService>();
        services.AddScoped<ICsvReaderHelper, CsvReaderHelper>();
        services.AddScoped<IGetAllUsersService, GetAllUsersService>();
    }
}