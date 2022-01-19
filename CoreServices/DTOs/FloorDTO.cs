using System.Collections.Generic;

namespace CoreServices.DTOs
{
    public class FloorDTO
    {
        public int Id { get; set; }
        public string FloorCode { get; set; }
        public string Coordination { get; set; }
        public string Canvas { get; set; }
        public virtual List<FloorsRoomsDTO> Rooms { get; set; }

    }
}
