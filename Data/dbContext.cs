using Microsoft.EntityFrameworkCore;
using Solar_Tracker.Models;

namespace Solar_Tracker.Data
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options) : base(options) { }

        public DbSet<Estabelecimento> Estabelecimentos { get; set; }
        public DbSet<PlacaSolar> PlacaSolares { get; set; }
        public DbSet<RegistroEnergia> RegistroEnergias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; } 

    }
}
