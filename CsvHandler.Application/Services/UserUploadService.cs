using System.Globalization;
using CsvHandler.Core.Domain.Entities;
using CsvHandler.Core.RepositoryContracts;
using CsvHandler.Core.ServiceContracts;
using CsvHelper;
using Microsoft.AspNetCore.Http;

namespace CsvHandler.Core.Services;

public class UserUploadService(IUsersRepository usersRepository) : IUserUploadService
{
    public async Task<IEnumerable<User>> UploadUsersToDatabase(IFormFile file)
    {
        using var reader = new StreamReader(file.OpenReadStream());
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        var records = csv.GetRecords<User>();

        foreach (var record in records)
        {
            var existingUser = await usersRepository.GetByUserId(record.UserIdentifier);
            
            if (existingUser != null)
            {
                existingUser.Age = record.Age;
                existingUser.City = record.City;
                existingUser.PhoneNumber = record.PhoneNumber;
                existingUser.Email = record.Email;
            }

        }
        
        await usersRepository.AddAsync(records);

        return records;
    }
    
}