using CoreServices.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreServices.Interfaces
{
    public interface IRoomAmenity
    {
        Task<RoomAmenityDTO> AddAmenity(int roomId, int amenityId);
        Task RemoveAmenity(int roomId, int amenityId);

    }
}
