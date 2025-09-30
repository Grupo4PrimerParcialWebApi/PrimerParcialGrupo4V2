using Microsoft.EntityFrameworkCore;
using PrimerParcialGrupo4WebApi.Models;

namespace PrimerParcialGrupo4WebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Event> Events { get; set; } = null!;
    }
}