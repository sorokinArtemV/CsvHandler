using CsvHandler.Core.Users.DTO;
using Microsoft.AspNetCore.Http;

namespace CsvHandler.Core.ServiceContracts;

public interface IUserUploadService
{
    /// <summary>
    /// Uploads users to database
    /// </summary>
    /// <param name="file">The file to upload.</param>
    /// <returns>A tuple containing the list of new users and the list of existing users.</returns>
    Task<(List<UserDto> NewUsers, List<UserDto> ExistingUsers)> UploadUsersToDatabase(IFormFile file);
}