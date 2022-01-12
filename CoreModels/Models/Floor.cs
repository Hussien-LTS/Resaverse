using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreModels.Models
{
    public class Floor
    {
        public int Id { get; set; }
        public string FloorCode { get; set; }
        public int CoOrdination { get; set; }

        #nullable enable
        public string? Canvas { get; set; }
        public string? FloorSize { get; set; }

        #nullable disable
        public virtual List<Room> Rooms { get; set; }

    }
}
