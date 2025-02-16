using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Vehicle> Vehicles {get; set;}

    public DbSet<Establecimiento> Establecimientos {get; set;}

    /*internal async Task SaveChangesAsync()
    {
          throw new NotImplementedException();
    }*/
}
