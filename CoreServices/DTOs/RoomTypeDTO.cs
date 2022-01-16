using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreServices.DTOs
{
    public class RoomTypeDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public virtual List<AminitiesRoomsDTO> Rooms { get; set; }

    }
}
