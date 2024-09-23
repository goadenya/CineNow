using CineNow.Domain.Common;
using CineNow.Domain.Common.Enums;
using CineNow.Domain.Common.Interfaces;

namespace CineNow.Domain.Entities
{
    public class Movie : BaseAuditableEntity
    {
        public int? Rank { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? BigImageUrl { get; set; }
        public List<string>? Genre { get; set; }
        public string? ThumbnailUrl { get; set; }
        public string? Rating { get; set; }
        public float? RatingAsNumber { get; set; }
        public int? Year { get; set; }
        public string? ImdbId { get; set; }
        public string? ImdbLink { get; set; }
        public List<Showtime>? Showtimes { get; set; }
        public List<Language>? AudioLanguages { get; set; }
        public List<Language>? SubtitleLanguages { get; set; }
    }
}
