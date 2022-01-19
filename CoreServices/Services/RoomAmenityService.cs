using CoreServices.DTOs;
using CoreServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreServices.Services
{
    public class RoomAmenityService : IRoomAmenity
    {
        public RoomAmenityDTO AddAmenity(int roomId, int AmenityId)
        {
            throw new NotImplementedException();
        }

        public List<RoomAmenityDTO> GetRoomAmenities(int roomId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAmenity(int roomId, int AmenityId)
        {
            throw new NotImplementedException();
        }
    }
}
