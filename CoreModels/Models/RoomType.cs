using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreModels.Models
{
    public class RoomType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public virtual List<Room> Rooms { get; set; }
    }
}
