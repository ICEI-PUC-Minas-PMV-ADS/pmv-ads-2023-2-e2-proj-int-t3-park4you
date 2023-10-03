using Microsoft.EntityFrameworkCore;

namespace Park4You.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options) { }

        public DbSet<cadast_Usuario> cadast_Usuario { get; set; }
    }
}
