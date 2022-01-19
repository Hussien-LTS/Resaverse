using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreServices.DTOs
{
    public class AminitiesRoomsDTO
    {
        public int RoomID { get; set; }
        public string RoomCode { get; set; }
        public int FloorId { get; set; }
        public string FloorCode { get; set; }
        public bool Availability { get; set; }

    }
}
