using AnimeRecommender.Application.Interfaces;
using AnimeRecommender.Domain.Entities;

using Microsoft.EntityFrameworkCore;

namespace AnimeRecommender.Infrastructure.Persistence.Repositories
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly AnimeRecommenderDbContext _context;

        public FavoriteRepository(AnimeRecommenderDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(FavoriteAnime favorite)
        {
            await _context.FavoriteAnimes.AddAsync(favorite);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FavoriteAnime>> GetByUserIdAsync(Guid userId)
        {
            return await _context.FavoriteAnimes
                .Where(f => f.UserId == userId)
                .ToListAsync();
        }

        public async Task DeleteAsync(Guid favoriteId)
        {
            var favorite = await _context.FavoriteAnimes.FindAsync(favoriteId);
            if (favorite != null)
            {
                _context.FavoriteAnimes.Remove(favorite);
                await _context.SaveChangesAsync();
            }
        }
    }
}
