using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreModels.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int FloorId { get; set; }
        public int RoomTypeId{ get; set; }

        public string RoomCode { get; set; }
        public bool Availability { get; set; }

        public int Capacity { get; set; }
        #nullable enable
        public string? Coordonation { get; set; }
        public string? Canvas { get; set; }
        #nullable disable

        public virtual Floor Floor { get; set; }
        public virtual RoomType RoomType { get; set; }
        public virtual List<RoomAmenity> RoomAmenities{ get; set; }
        public virtual List<Reservation> Reservations { get; set; }

    }
}
