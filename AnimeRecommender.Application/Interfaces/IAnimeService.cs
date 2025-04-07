using AnimeRecommender.Domain.Entities;

namespace AnimeRecommender.Application.Interfaces
{
    public interface IAnimeService
    {
        Task<List<Anime>> GetSimilarAnimes(string animeName);
    }
}
