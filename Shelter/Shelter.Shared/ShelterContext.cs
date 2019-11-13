using Microsoft.EntityFrameworkCore;

namespace Shelter.Shared
{
  public class ShelterContext : DbContext
  {
    public ShelterContext(DbContextOptions<ShelterContext> options) : base(options)
    {

    }

    public DbSet<Animal> Animals { get; set; }
    public DbSet<Shelter> Shelter { get; set; }
    public DbSet<Person> Person { get; set; }
  }
}