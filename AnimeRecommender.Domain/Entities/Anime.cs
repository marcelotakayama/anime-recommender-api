namespace AnimeRecommender.Domain.Entities
{
    public class Anime
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<string> Genres { get; set; }
        public double Score { get; set; }
        public string Synopsis { get; set; }

        public Anime(int id, string title, List<string> genres, double score, string synopsis)
        {
            Id = id;
            Title = title;
            Genres = genres;
            Score = score;
            Synopsis = synopsis;
        }
    }
}