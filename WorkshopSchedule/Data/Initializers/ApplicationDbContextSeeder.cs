namespace WorkshopSchedule.Data.Initializers;

public static class ApplicationDbContextSeeder
{
    public static async Task SeedDbContextAsync(
        this IServiceProvider serviceProvider,
        IConfiguration configuration,
        IWebHostEnvironment environment
    )
    {
        using var serviceScope = serviceProvider.CreateScope();
        var context = serviceScope?.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    }
}
