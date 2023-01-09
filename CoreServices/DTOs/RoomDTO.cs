using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreServices.DTOs
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public string RoomCode { get; set; }
        public bool Availability { get; set; }
        public int Capacity { get; set; }
        public string Coordonation { get; set; }
        public string Canvas { get; set; }
        public virtual FloorsDTO Floor { get; set; }
        public virtual RoomTypesDTO RoomType { get; set; }
        public virtual List<AmenitiesDTO> Amenities { get; set; }
        public virtual List<ReservationsDTO> Reservations { get; set; }


    }
}
