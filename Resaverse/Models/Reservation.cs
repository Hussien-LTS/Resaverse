using Resaverse.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resaverse.Models
{
    public class Reservation
    {
        public int RoomId { get; set; }
        public string UserId { get; set; }
        public DateTime ReservationStartDate { get; set; }
        public DateTime ReservationEndDate { get; set; }
        public ReservationStatus ReservationStatus { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Room Room { get; set; }
    }

    public enum ReservationStatus
    {
        Pending,
        Accepted,
        Rejected
    }
}
