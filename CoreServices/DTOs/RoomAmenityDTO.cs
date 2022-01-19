using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreServices.DTOs
{
    public class RoomAmenityDTO
    {
        public int RoomId { get; set; }
        public int AmenityId { get; set; }

        public virtual RoomDTO Room { get; set; }
        public virtual AmenityDTO Amenity { get; set; }
    }
}
