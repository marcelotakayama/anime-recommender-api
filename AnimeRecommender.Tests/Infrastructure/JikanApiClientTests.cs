using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit;
using Moq;
using Moq.Protected;
using FluentAssertions;
using AnimeRecommender.Infrastructure;
using AnimeRecommender.Domain;

namespace AnimeRecommender.Tests.Infrastructure
{
    public class JikanApiClientTests
    {
        [Fact]
        public async Task GetSimilarAnimes_ReturnsAnimes_WhenApiReturnsData()
        {
            // Arrange
            var fakeJson = """
            {
              "data": [
                {
                  "mal_id": 1,
                  "title": "Naruto",
                  "genres": [{"name": "Action"}, {"name": "Adventure"}],
                  "score": 8.0,
                  "synopsis": "A ninja story"
                }
              ]
            }
            """;

            var handlerMock = new Mock<HttpMessageHandler>();

            handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(fakeJson, Encoding.UTF8, "application/json")
                });

            var httpClient = new HttpClient(handlerMock.Object);
            var jikanClient = new JikanApiClient(httpClient);

            // Act
            var result = await jikanClient.GetSimilarAnimes("Naruto");

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
            result[0].Title.Should().Be("Naruto");
            result[0].Genres.Should().Contain("Action");
            result[0].Score.Should().Be(8.0);
        }
    }
}
