using CsvHandler.Core.Domain.Constants;
using CsvHandler.Core.Users.DTO;

namespace CsvHandler.Core.ServiceContracts;

public interface IGetAllUsersService
{
    /// <summary>
    ///  Gets all matching users from the database.
    /// </summary>
    /// <param name="query">Query parameters </param>
    /// <returns>List of UserDto</returns>
    Task<List<UserDto>> GetAllMatchingUsers(QueryParams query);
}