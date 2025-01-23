using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }

    /*internal async Task SaveChangesAsync()
    {
          throw new NotImplementedException();
    }*/
}
