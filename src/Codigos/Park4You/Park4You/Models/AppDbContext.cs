using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.VisualStudio.Debugger.Contracts;

namespace Park4You.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options) { }

        public DbSet<cadast_Usuario> cadast_Usuario { get; set; }

        public DbSet<Endereco_Vaga> endereco_Vaga  { get; set; }
    }
}
