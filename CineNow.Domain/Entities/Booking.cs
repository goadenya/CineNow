using CineNow.Domain.Common;

namespace CineNow.Domain.Entities
{
    public class Booking : BaseAuditableEntity
    {
        public int? ShowTimeId { get; set; }
        public Showtime? Showtime { get; set; }
        public Guid? Code { get; set; }
    }
}