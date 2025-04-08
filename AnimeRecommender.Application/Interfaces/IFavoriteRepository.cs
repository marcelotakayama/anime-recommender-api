using AnimeRecommender.Domain.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeRecommender.Application.Interfaces
{
    public interface IFavoriteRepository
    {
        Task AddAsync(FavoriteAnime favorite);
        Task<IEnumerable<FavoriteAnime>> GetByUserIdAsync(Guid userId);
        Task DeleteAsync(Guid favoriteId);
    }
}
