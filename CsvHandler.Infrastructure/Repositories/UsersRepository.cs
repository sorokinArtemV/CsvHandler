using CsvHandler.Core.Domain.Constants;
using CsvHandler.Core.Domain.Entities;
using CsvHandler.Core.RepositoryContracts;
using CsvHandler.Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace CsvHandler.Infrastructure.Repositories;

public class UsersRepository(UsersDbContext dbContext) : IUsersRepository
{
    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await dbContext.Users.ToListAsync();
    }

    public async Task<int> AddUsersAsync(IEnumerable<User> entities)
    {
        dbContext.Users.AddRange(entities);
        return await SaveChangesAsync();
    }

    public async Task<int> UpdateUsersAsync(IEnumerable<User> entities)
    {
        foreach (var user in entities)
        {
            var existingEntity = dbContext.Users.Local.FirstOrDefault(e => e.UserIdentifier == user.UserIdentifier);
            if (existingEntity != null)
            {
                dbContext.Entry(existingEntity).State = EntityState.Detached;
            }

            dbContext.Users.Update(user);
        }

        return await SaveChangesAsync();
    }

    public Task<User?> GetByUserId(Guid id)
    {
        return dbContext.Users.FirstOrDefaultAsync(x => x.UserIdentifier == id);
    }

    public async Task<IEnumerable<User>> GetAllMatchingUsersAsync(
        string? searchTerm,
        int pageSize,
        SortDirection sortDirection)
    {
        var searchTermLower = searchTerm?.ToLower();

        var baseQuery = dbContext.Users
            .Where(x => searchTermLower == null || x.Username!.ToLower().Contains(searchTermLower));

        return sortDirection switch
        {
            SortDirection.Asc => await baseQuery
                .OrderBy(x => x.Username)
                .Take(pageSize)
                .ToListAsync(),
            SortDirection.Desc => await baseQuery
                .OrderByDescending(x => x.Username)
                .Take(pageSize)
                .ToListAsync(),
            _ => throw new ArgumentOutOfRangeException(nameof(sortDirection), sortDirection, null)
        };
    }

    private async Task<int> SaveChangesAsync()
    {
        return await dbContext.SaveChangesAsync();
    }
}