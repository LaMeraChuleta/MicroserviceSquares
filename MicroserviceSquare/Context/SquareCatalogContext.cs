using MicroserviceSquare.Models;
using Microsoft.EntityFrameworkCore;

namespace MicroserviceSquare.Context
{
    public class SquareCatalogContext : DbContext
    {
        public SquareCatalogContext()
        {

        }
        public SquareCatalogContext(DbContextOptions<SquareCatalogContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Delegation>().Property(d => d.DelegationId).HasMaxLength(6).ValueGeneratedNever();

            modelBuilder.Entity<Square>().Property(s => s.SquareId).HasMaxLength(6);
            modelBuilder.Entity<Square>().Property(s => s.DelegationId).IsRequired();

            modelBuilder.Entity<Section>().Property(s => s.SquareId).HasMaxLength(6);
            modelBuilder.Entity<Section>().Property(s => s.SquareId).IsRequired();

            modelBuilder.Entity<Lane>().HasOne(l => l.Square).WithMany(s => s.Lanes).IsRequired().OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Lane>().HasOne(l => l.Section).WithMany(s => s.Lanes).IsRequired().OnDelete(DeleteBehavior.NoAction);
                                    
        }
        public DbSet<Delegation> Delegations { get; set; }
        public DbSet<Square> Squares { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Lane> Lanes { get; set; }
        public DbSet<TypeLane> TypeLanes { get; set; }
    }
}
