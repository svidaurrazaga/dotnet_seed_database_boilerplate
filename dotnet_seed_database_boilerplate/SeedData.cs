using dotnet_seed_database_boilerplate.Repo;
using Microsoft.EntityFrameworkCore;

namespace dotnet_seed_database_boilerplate
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            await AddTestData(services.GetRequiredService<BeerCaveDbContext>());
        }

        public static async Task AddTestData(BeerCaveDbContext context)
        {
            if (context.Beers.Any())
            {
                return; // we already have data
            }

            context.Beers.Add(new Models.Beer
            {
                Key = 1,
                Name = "Surfbird",
                Type = "Golden Lager",
                Ounces = 16
            });

            context.Beers.Add(new Models.Beer
            {
                Key = 2,
                Name = "Modelo",
                Type = "Mexican Lager",
                Ounces = 12
            });

            context.Beers.Add(new Models.Beer
            {
                Key = 3,
                Name = "Fukuoka",
                Type = "Japense Rice Lager",
                Ounces = 16
            });

            await context.SaveChangesAsync();
        }
    }
}
