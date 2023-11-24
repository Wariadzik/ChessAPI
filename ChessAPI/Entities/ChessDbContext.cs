using Microsoft.EntityFrameworkCore;

namespace ChessAPI.Entities
{
    public class ChessDbContext : DbContext
    {
        private string _connectionString = "Server=DESKTOP-LAA39MQ;Database=ChessDb;Trusted_Connection=True;";
        public DbSet<Opening> Openings { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<Tournament>()
                .Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(75);

            modelBuilder.Entity<Opening>()
                .Property(o => o.Name)
                .IsRequired()
                .HasMaxLength(50);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
