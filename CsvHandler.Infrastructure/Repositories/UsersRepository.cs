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

    private async Task<int> SaveChangesAsync()
    {
        return await dbContext.SaveChangesAsync();
    }
}