using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PokeAPI.Domain.Entities;

namespace PokeAPI.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Pokemon> Pokemons { get; set; } = null!;
        public DbSet<PokemonColorGroup> PokemonColorGroups { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pokemon>()
                .HasOne(p => p.ColorGroup)
                .WithMany(g => g.Pokemons)
                .HasForeignKey(p => p.ColorGroupId);

            modelBuilder.Entity<PokemonColorGroup>()
                .HasIndex(g => g.Color)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}