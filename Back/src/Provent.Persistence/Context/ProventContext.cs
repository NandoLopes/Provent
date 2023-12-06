using Microsoft.EntityFrameworkCore;
using Provent.Domain;

namespace Provent.Persistence.Context
{
    public class ProventContext :DbContext
    {
        public ProventContext(DbContextOptions<ProventContext> options) : base(options){ }
        public DbSet<Event> Events { get; set; }   
        public DbSet<Batch> Batches { get; set; }   
        public DbSet<Speaker> Speakers { get; set; }   
        public DbSet<SpeakerEvent> SpeakersEvents { get; set; }   
        public DbSet<SocialNetwork> SocialNetworks { get; set; }   

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<SpeakerEvent>()
                .HasKey(PE => new {PE.EventId, PE.SpeakerId});

            modelBuilder.Entity<Event>()
                .HasMany(e => e.SocialNetworks)
                .WithOne(rs => rs.Event)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Speaker>()
                .HasMany(p => p.SocialNetworks)
                .WithOne(rs => rs.Speaker)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Event>()
                .HasMany(e => e.Batches)
                .WithOne(rs => rs.Event)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}