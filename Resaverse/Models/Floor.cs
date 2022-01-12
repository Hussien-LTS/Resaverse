using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Resaverse.Models
{
    public class Floor
    {
        public int Id { get; set; }
        public string FloorCode { get; set; }
        public int CoOrdination { get; set; }
        //public string? Canvas { get; set; }

        //public string? FloorSize { get; set; }
        public virtual List<Room> Rooms { get; set; }

    }
}
