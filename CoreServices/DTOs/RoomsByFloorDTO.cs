using System.Collections.Generic;

namespace CoreServices.DTOs
{
    public class RoomsByFloorDTO
    {
        public int FloorID { get; set; }
        public string FloorCode { get; set; }
        public int Count { get; set; }

        public virtual List<RoomsDTO> Result { get; set; }
    }
}
