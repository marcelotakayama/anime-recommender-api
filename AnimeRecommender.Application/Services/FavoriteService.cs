using AnimeRecommender.Domain.Entities;

using AnimeRecommender.Application.Interfaces;
using AnimeRecommender.Domain.Entities;

namespace AnimeRecommender.Application.Services
{
    public class FavoriteService
    {
        private readonly IFavoriteRepository _repository;
        private readonly IJikanService _jikanService;

        public FavoriteService(IFavoriteRepository repository, IJikanService jikanService)
        {
            _repository = repository;
            _jikanService = jikanService;
        }

        public async Task AddFavoriteAsync(string animeId, Guid userId)
        {
            var favorite = await _jikanService.GetAnimeDetailsAsync(animeId, userId);
            await _repository.AddAsync(favorite);
        }

        public Task<IEnumerable<FavoriteAnime>> GetFavoritesByUserIdAsync(Guid userId) =>
            _repository.GetByUserIdAsync(userId);

        public Task RemoveFavoriteAsync(Guid favoriteId) =>
            _repository.DeleteAsync(favoriteId);
    }

}
