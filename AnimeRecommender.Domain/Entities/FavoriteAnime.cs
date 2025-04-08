using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeRecommender.Domain.Entities
{
    public class FavoriteAnime
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        public string AnimeIdJikan { get; set; } // ID da Jikan API
        public string AnimeTitle { get; set; }
        public string? Description { get; set; }
        public string? Genre { get; set; }
        public double? Score { get; set; }
        public int? Episodes { get; set; }
        public string? Type { get; set; }
        public string? ImageUrl { get; set; }

        public User User { get; set; } // navegação
    }

}
