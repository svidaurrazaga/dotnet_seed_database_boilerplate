using Microsoft.EntityFrameworkCore;

namespace dotnet_seed_database_boilerplate.Repo
{
    public class BeerCaveDbContext : DbContext
    {
        public BeerCaveDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<Models.Beer> Beers { get; set; }
    }
}
