using Microsoft.EntityFrameworkCore;

namespace EmisionAPI.Models.ContextModel
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Emission> Emissions { get; set; }
    }
}
