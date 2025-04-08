using AnimeRecommender.Domain.Entities;

namespace AnimeRecommender.Application.Interfaces
{
    public interface IJikanService
    {
        Task<FavoriteAnime> GetAnimeDetailsAsync(string animeId, Guid userId);
    }
}