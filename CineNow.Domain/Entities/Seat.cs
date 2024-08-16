using CineNow.Domain.Common;

namespace CineNow.Domain.Entities
{
    public class Seat : BaseAuditableEntity
    {
        public int? SeatRowId { get; set; }
        public SeatRow? SeatRow { get; set; }
        public int? SeatNumber { get; set; }
        public bool? SeatIsBooked { get; set; }
    }
}
