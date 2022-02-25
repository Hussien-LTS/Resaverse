using System.Collections.Generic;

namespace CoreModels.Models
{
    public class Amenity
    {
        public int Id { get; set; }
        public string AmenityName { get; set; }
        public virtual List<RoomAmenity> RoomAmenities { get; set; }
    }
}
