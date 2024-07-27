using AutoMapper;
using CsvHandler.Application.helpers;
using CsvHandler.Core.Domain.Entities;
using CsvHandler.Core.RepositoryContracts;
using CsvHandler.Core.ServiceContracts;
using CsvHandler.Core.Users.DTO;
using Microsoft.AspNetCore.Http;

namespace CsvHandler.Application.Services;

public class UserUploadService(
    IUsersRepository usersRepository,
    ICsvReaderHelper csvReaderHelper,
    IMapper mapper
) : IUserUploadService
{
    public async Task<(List<UserDto> NewUsers, List<UserDto> ExistingUsers)> UploadUsersToDatabase(IFormFile file)
    {
        var records = csvReaderHelper.ReadCsvFile(file);
        var (existingUsers, newUsers) = await ProcessUsersAsync(records);

        if (newUsers.Count != 0)
        {
            await usersRepository.AddUsersAsync(newUsers.Select(mapper.Map<User>).ToList());
        }

        if (existingUsers.Count != 0)
        {
            await usersRepository.UpdateUsersAsync(existingUsers.Select(mapper.Map<User>).ToList());
        }

        return (NewUsers: newUsers, ExistingUsers: existingUsers);
    }

    private async Task<(List<UserDto> existingUsers, List<UserDto> newUsers)> ProcessUsersAsync(List<UserDto> records)
    {
        var existingUsers = new List<UserDto>();
        var newUsers = new List<UserDto>();

        foreach (var record in records)
        {
            var existingUser = await usersRepository.GetByUserId(record.UserIdentifier);

            if (existingUser != null)
            {
                existingUser.Age = record.Age;
                existingUser.City = record.City;
                existingUser.PhoneNumber = record.PhoneNumber;
                existingUser.Email = record.Email;
                existingUsers.Add(mapper.Map<UserDto>(existingUser));
            }
            else
            {
                newUsers.Add(record);
            }
        }

        return (existingUsers, newUsers);
    }
}