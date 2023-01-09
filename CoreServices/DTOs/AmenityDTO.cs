using System.Collections.Generic;

namespace CoreServices.DTOs
{
    public class AmenityDTO
    {
        public int Id { get; set; }
        public string AmenityName { get; set; }
        public virtual List<AminitiesRoomsDTO> Rooms { get; set; }

    }
}
