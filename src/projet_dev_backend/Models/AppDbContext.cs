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

        public DbSet<Reserva> Reservas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reserva>()
     .HasOne(r => r.EnderecoVaga)
     .WithMany(ev => ev.Reservas)
     .HasForeignKey(r => r.EnderecoVagaId);

            modelBuilder.Entity<Usuarios>()
                .HasMany(u => u.Reservas)
                .WithOne(r => r.Usuario)
                .HasForeignKey(r => r.UsuarioId);

            // Outras configurações...

            modelBuilder.Entity<Reserva>()
                .HasOne(r => r.Usuario)
                .WithMany(u => u.Reservas)
                .HasForeignKey(r => r.UsuarioId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

    