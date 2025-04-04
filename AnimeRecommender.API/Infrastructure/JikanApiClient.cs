using AnimeRecommender.API.Application;
using AnimeRecommender.API.Domain;
using System.Text.Json;

namespace AnimeRecommender.API.Infrastructure
{
    public class JikanApiClient : IAnimeService
    {
        private readonly HttpClient _httpClient;
        private const string JikanBaseUrl = "https://api.jikan.moe/v4";

        public JikanApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Anime>> GetSimilarAnimes(string animeName)
        {
            var response = await _httpClient.GetStringAsync($"{JikanBaseUrl}/anime?q={animeName}");
            var json = JsonDocument.Parse(response);
            var animes = new List<Anime>();

            foreach (var element in json.RootElement.GetProperty("data").EnumerateArray())
            {
                var id = element.GetProperty("mal_id").GetInt32();
                var title = element.GetProperty("title").GetString() ?? "Sem título";
                var genres = element.GetProperty("genres").EnumerateArray().Select(g => g.GetProperty("name").GetString() ?? "Desconhecido").ToList();

                double score = 0;
                if (element.TryGetProperty("score", out var scoreProperty) && scoreProperty.ValueKind == JsonValueKind.Number)
                {
                    score = scoreProperty.GetDouble();
                }

                var synopsis = element.GetProperty("synopsis").GetString() ?? "Sem sinopse disponível";

                animes.Add(new Anime(id, title, genres, score, synopsis));
            }

            return animes;
        }
    }
}
