using System;

namespace CoreModels.Models
{
    public class Reservation
    {
        public int RoomId { get; set; }
        public string UserId { get; set; }

        #nullable enable
        public string? Reason { get; set; }
        #nullable disable
        public DateTime ReservationStartDate { get; set; }
        public DateTime ReservationEndDate { get; set; }
        public ReservationStatus ReservationStatus { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Room Room { get; set; }
    }

    public enum ReservationStatus
    {
        PENDING,
        ACCEPTED,
        REJECTED,
        DELETED,
        EXPIRED
    }
}
