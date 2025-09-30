using Microsoft.EntityFrameworkCore;
using PrimerParcialGrupo4WebApi.Models;

namespace PrimerParcialGrupo4WebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Registrar la entidad Event
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<Event>(e =>
            {
                e.ToTable("Events");
                e.Property(ev => ev.Title).HasMaxLength(200).IsRequired();
                e.Property(ev => ev.Location).HasMaxLength(200).IsRequired();
                e.HasIndex(ev => new { ev.Title, ev.StartAt }); // Ejemplo de índice compuesto
            });
        }
    }
}