using Microsoft.EntityFrameworkCore;
using Provent.Domain;

namespace Provent.Persistence.Context
{
    public class ProventContext :DbContext
    {
        public ProventContext(DbContextOptions<ProventContext> options) : base(options){ }
        public DbSet<Evento> Eventos { get; set; }   
        public DbSet<Lote> Lotes { get; set; }   
        public DbSet<Palestrante> Palestrantes { get; set; }   
        public DbSet<PalestranteEvento> PalestrantesEventos { get; set; }   
        public DbSet<RedeSocial> RedesSociais { get; set; }   

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<PalestranteEvento>()
                .HasKey(PE => new {PE.EventoId, PE.PalestranteId});

            modelBuilder.Entity<Evento>()
                .HasMany(e => e.RedesSociais)
                .WithOne(rs => rs.Evento)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Palestrante>()
                .HasMany(p => p.RedesSociais)
                .WithOne(rs => rs.Palestrante)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Evento>()
                .HasMany(e => e.Lotes)
                .WithOne(rs => rs.Evento)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}