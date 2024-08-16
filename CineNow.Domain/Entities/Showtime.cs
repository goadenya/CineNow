using CineNow.Domain.Common;

namespace CineNow.Domain.Entities
{
    public class Showtime : BaseAuditableEntity
    {
        public List<Booking>? Bookings { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public Movie? Movie { get; set; }
        public int? MovieId { get; set; }
        public Theater? Theater { get; set; }
        public int? TheaterId { get; set; }
        public Language? AudioLanguage { get; set; }
        public Language? SubtitleLanguage { get; set; }
    }
    public enum Language
    {
        None = 0,
        English,
        Swedish,
        Finnish,
        Norwegian,
        Danish,
        German,
        Dutch,
        French,
        Italian,
        Spanish,
        Portuguese,
        Turkish,
        Persian,
        Arabic,
        Hindi,
        Urdu,
        ChineseMandarin,
        Korean,
        Japanese,
    }
}
