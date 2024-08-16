using CineNow.Domain.Common;

namespace CineNow.Domain.Entities
{
    public class SeatRow : BaseAuditableEntity
    {
        public int? TheaterId { get; set; }
        public Theater? Theater { get; set; }
        public int? RowNumber { get; set; }
        public List<Seat>? Seats { get; set; }
    }
}
