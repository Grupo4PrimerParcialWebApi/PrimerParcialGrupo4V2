using Microsoft.EntityFrameworkCore;
using PrimerParcialGrupo4WebApi.Models;

namespace PrimerParcialGrupo4WebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; } = null!;
        public DbSet<SupportTicket> SupportTickets { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Productos");
                entity.Property(p => p.Price).HasPrecision(18, 2);
                entity.Property(p => p.CreatedAt).HasDefaultValueSql("GETUTCDATE()");
            });

            // (opcional) Configuración de SupportTicket si quisieras en el futuro
        }
    }
}