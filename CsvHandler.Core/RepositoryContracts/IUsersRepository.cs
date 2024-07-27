using CsvHandler.Core.Domain.Constants;
using CsvHandler.Core.Domain.Entities;

namespace CsvHandler.Core.RepositoryContracts;

public interface IUsersRepository
{
    /// <summary>
    /// Get all users from database
    /// </summary>
    /// <returns></returns>
    public Task<IEnumerable<User>> GetAllAsync();

    /// <summary>
    /// Get all matching users from database
    /// </summary>
    /// <param name="searchTerm">Search term</param>
    /// <param name="pageSize">Page size</param>
    /// <param name="sortDirection">Sort direction</param>
    /// <returns></returns>
    public Task<IEnumerable<User>> GetAllMatchingUsersAsync(
        string? searchTerm,
        int pageSize,
        SortDirection sortDirection);

    /// <summary>
    /// Add new users to database
    /// </summary>
    /// <param name="entities">List of users to be added</param>
    /// <returns>Number of rows affected</returns>
    public Task<int> AddUsersAsync(IEnumerable<User> entities);

    /// <summary>
    /// Update users in database
    /// </summary>
    /// <param name="entities">List of users to be updated</param>
    /// <returns>Number of rows affected</returns>
    public Task<int> UpdateUsersAsync(IEnumerable<User> entities);

    /// <summary>
    /// Get user by id
    /// </summary>
    /// <param name="id">User id</param>
    /// <returns>User</returns>
    public Task<User?> GetByUserId(Guid id);
}