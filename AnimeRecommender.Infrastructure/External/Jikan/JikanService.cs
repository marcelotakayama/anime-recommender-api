using AnimeRecommender.Application.Interfaces;
using AnimeRecommender.Domain.Entities;

using System.Text.Json;

namespace AnimeRecommender.Infrastructure.External.Jikan
{
    public class JikanService : IJikanService
    {
        private readonly HttpClient _httpClient;

        public JikanService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://api.jikan.moe/v4/");
        }

        public async Task<FavoriteAnime> GetAnimeDetailsAsync(string animeId, Guid userId)
        {
            var response = await _httpClient.GetAsync($"anime/{animeId}");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var json = JsonDocument.Parse(content);

            var data = json.RootElement.GetProperty("data");

            return new FavoriteAnime
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                AnimeIdJikan = animeId,
                AnimeTitle = data.GetProperty("title").GetString(),
                Description = data.GetProperty("synopsis").GetString(),
                Genre = string.Join(", ", data.GetProperty("genres").EnumerateArray().Select(g => g.GetProperty("name").GetString())),
                Score = data.TryGetProperty("score", out var scoreProp) ? scoreProp.GetDouble() : null,
                Episodes = data.TryGetProperty("episodes", out var episodesProp) ? episodesProp.GetInt32() : null,
                Type = data.GetProperty("type").GetString(),
                ImageUrl = data.GetProperty("images").GetProperty("jpg").GetProperty("image_url").GetString()
            };
        }
    }
}
