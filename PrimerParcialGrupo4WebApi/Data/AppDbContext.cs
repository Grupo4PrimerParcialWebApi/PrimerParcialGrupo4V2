using Microsoft.EntityFrameworkCore;
using PrimerParcialGrupo4WebApi.Model;

namespace PrimerParcialGrupo4WebApi.Data
{
    public class AppDbContext : DbContext
    {
        // Constructor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSet para tu entidad Producto
        public DbSet<Producto> Productos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.ToTable("Productos");  // Nombre de tabla
                entity.Property(p => p.Price).HasPrecision(18, 2); // Precisión decimal
                entity.Property(p => p.CreatedAt).HasDefaultValueSql("GETUTCDATE()"); // Fecha por defecto
            });
        }
    }
}