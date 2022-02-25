using System.Collections.Generic;

namespace CoreModels.Models
{
    public class Floor
    {
        public int Id { get; set; }
        public string FloorCode { get; set; }
        public string Coordination { get; set; }
#nullable enable
        public string? Canvas { get; set; }
#nullable disable
        public virtual List<Room> Rooms { get; set; }
    }
}
