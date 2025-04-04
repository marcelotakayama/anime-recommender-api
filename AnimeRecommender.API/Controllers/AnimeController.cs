using AnimeRecommender.Application;
using Microsoft.AspNetCore.Mvc;

namespace AnimeRecommender.API.Controllers
{
    [ApiController]
    [Route("api/animes")]
    public class AnimeController : ControllerBase
    {
        private readonly IAnimeService _animeService;

        public AnimeController(IAnimeService animeService)
        {
            _animeService = animeService;
        }

        [HttpGet("similares")]
        public async Task<IActionResult> GetSimilarAnimes([FromQuery] string anime)
        {
            var animes = await _animeService.GetSimilarAnimes(anime);
            return Ok(animes);
        }
    }
}
