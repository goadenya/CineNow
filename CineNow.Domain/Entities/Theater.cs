using CineNow.Domain.Common;

namespace CineNow.Domain.Entities
{
    public class Theater : BaseAuditableEntity
    {
        public string? Name { get; set; }
        public string? Info { get; set; }
        public int? Numbering { get; set; }
        public int? VenueId { get; set; }
        public Venue? Venue { get; set; }
        public List<SeatRow>? SeatRows { get; set; }
    }
}
