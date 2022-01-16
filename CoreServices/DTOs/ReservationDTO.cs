using CoreModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreServices.DTOs
{
    public class ReservationDTO
    {
        public string Reason { get; set; }
        public DateTime ReservationStartDate { get; set; }
        public DateTime ReservationEndDate { get; set; }
        public string ReservationStatus { get; set; }
        public virtual UserDTO User { get; set; }
        public virtual AminitiesRoomsDTO Room { get; set; }


    }
}
