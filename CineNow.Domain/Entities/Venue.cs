using CineNow.Domain.Common;

namespace CineNow.Domain.Entities
{
    public class Venue : BaseAuditableEntity
    {
        public string? Name { get; set; }
        public DateTime? OpeningTime { get; set; }
        public DateTime? ClosingTime { get; set; }
        public string? Address { get; set; }
        public List<Theater>? Theaters { get; set; }
    }
}
