using Microsoft.EntityFrameworkCore;

namespace WorkshopSchedule.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options) { }
}
