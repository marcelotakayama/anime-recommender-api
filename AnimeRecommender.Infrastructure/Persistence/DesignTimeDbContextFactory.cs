using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AnimeRecommender.Infrastructure.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AnimeRecommenderDbContext>
    {
        public AnimeRecommenderDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AnimeRecommenderDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AnimeRecommenderDb;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new AnimeRecommenderDbContext(optionsBuilder.Options);
        }
    }
}
