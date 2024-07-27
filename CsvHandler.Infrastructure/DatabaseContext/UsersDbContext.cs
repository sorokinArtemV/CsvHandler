using CsvHandler.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CsvHandler.Infrastructure.DatabaseContext;

public class UsersDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
}