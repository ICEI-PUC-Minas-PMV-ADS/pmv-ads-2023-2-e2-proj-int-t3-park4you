using Microsoft.EntityFrameworkCore;
using Park4You.Models;

namespace projet_dev_backend.Models
{
    public class AppDbContext : DbContext
    {   
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            //Database.EnsureCreated();
        }

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Endereco_Vaga> Endereco_Vagas { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<Gestor> Gestor { get; set; }
    }

    

    }

