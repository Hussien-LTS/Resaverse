using CoreServices.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreServices.Interfaces
{
    public interface IRoomAmenity
    {
        RoomAmenityDTO AddAmenity(int roomId, int AmenityId);
        List<RoomAmenityDTO> GetRoomAmenities(int roomId);
        Task RemoveAmenity(int roomId, int AmenityId);

    }
}
