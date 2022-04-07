using dotnet_seed_database_boilerplate.Repo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Use in-memory database for quick development and testing
builder.Services.AddDbContext<BeerCaveDbContext>(options => options.UseInMemoryDatabase("BeerCaveDb"));

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// initilize test data or log error
using (var seedScope = app.Services.CreateScope())
{
    var services = seedScope.ServiceProvider;
    try
    {
        dotnet_seed_database_boilerplate.SeedData.InitializeAsync(services).Wait();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred seeding the database.");
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
