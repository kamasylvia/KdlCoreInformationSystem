using Microsoft.EntityFrameworkCore;

namespace WorkshopSchedule.Data;

public class ApplicationDbContext : DbContext
{
    private readonly IConfiguration _configuration;

    public ApplicationDbContext(DbContextOptions options,
            IConfiguration configuration
    ) : base(options)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
    optionsBuilder.UseNpgsql(
        _configuration.GetConnectionString("PostgreSQL")
    );

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // builder.UseOpenIddict();

        /*
        builder.Entity<ApplicationUser>().Property<NewId>(user => user.Id).HasConversion(
            newId => newId.ToString(),
            str => new NewId(str)
        );

        builder.Entity<ApplicationRole>().Property<NewId>(user => user.Id).HasConversion(
            newId => newId.ToString(),
            str => new NewId(str)
        );
        */

    }
}
