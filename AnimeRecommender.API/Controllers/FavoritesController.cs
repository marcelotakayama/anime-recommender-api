using AnimeRecommender.Application.Services;
using AnimeRecommender.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnimeRecommender.API.Controllers
{
    [ApiController]
    [Route("api/users/{userId}/favorites")]
    public class FavoritesController : ControllerBase
    {
        private readonly FavoriteService _favoriteService;

        public FavoritesController(FavoriteService favoriteService)
        {
            _favoriteService = favoriteService;
        }

        [HttpPost]
        public async Task<IActionResult> AddFavorite(Guid userId, [FromBody] AddFavoriteRequest request)
        {
            await _favoriteService.AddFavoriteAsync(request.AnimeIdJikan, userId);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetFavorites(Guid userId)
        {
            var favorites = await _favoriteService.GetFavoritesByUserIdAsync(userId);
            return Ok(favorites);
        }

        [HttpDelete("{favoriteId}")]
        public async Task<IActionResult> RemoveFavorite(Guid userId, Guid favoriteId)
        {
            await _favoriteService.RemoveFavoriteAsync(favoriteId);
            return NoContent();
        }
    }

}
