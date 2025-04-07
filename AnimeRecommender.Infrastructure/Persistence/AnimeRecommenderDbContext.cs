using Microsoft.EntityFrameworkCore;
using AnimeRecommender.Domain.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace AnimeRecommender.Infrastructure.Persistence
{
    public class AnimeRecommenderDbContext : DbContext
    {
        public AnimeRecommenderDbContext(DbContextOptions<AnimeRecommenderDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        // Se quiser, já pode adicionar outros DbSets aqui no futuro:
        // public DbSet<Anime> Animes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Se quiser, adicione aqui configurações específicas, como:
            // modelBuilder.Entity<User>().HasKey(u => u.Id);
        }
    }
}
