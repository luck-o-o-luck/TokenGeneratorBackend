using Microsoft.EntityFrameworkCore;
using TokenGenerator.TokenGenerator.Domain.UserEntities;

namespace TokenGenerator.TokenGeneratorDataAccess;

public class UserDbContext : DbContext
{
    public DbSet<CustomIdentityUser> Users => Set<CustomIdentityUser>();
    public UserDbContext() => Database.EnsureCreated();
    
    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=helloapp.db");
    }
}