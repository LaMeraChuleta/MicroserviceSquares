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
        public SquareCatalogContext(DbContextOptions<SquareCatalogContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-HB3OGAHI\\MSSQLSERVER01;Database=testsquare;Trusted_Connection=True;");
            }                            
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
