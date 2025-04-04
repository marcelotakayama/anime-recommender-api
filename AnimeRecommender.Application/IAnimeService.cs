using AnimeRecommender.Application;
using AnimeRecommender.Domain;

namespace AnimeRecommender.Application
{
    public interface IAnimeService
    {
        Task<List<Anime>> GetSimilarAnimes(string animeName);
    }
}
