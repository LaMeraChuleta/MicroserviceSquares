using MicroserviceSquare.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviceSquare.Context
{
    public class SquareCatalogContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-79J7I41;Database=TestSquare;User Id=sa;Password=LaVacaLoca16;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Delegation>()
                .Property(d => d.DelegationId)
                .HasMaxLength(6)
                .ValueGeneratedNever();

            modelBuilder.Entity<Square>()
                .Property(s => s.SquareId)
                .HasMaxLength(6);
  
        }
        public DbSet<Delegation> Delegations { get; set; }
        public DbSet<Square> Squares { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Lane> Lanes { get; set; }
        public DbSet<TypeLane> TypeLanes { get; set; }

    }
}
