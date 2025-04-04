using AnimeRecommender.API.Domain;

namespace AnimeRecommender.API.Application
{
    public interface IAnimeService
    {
        Task<List<Anime>> GetSimilarAnimes(string animeName);
    }
}
