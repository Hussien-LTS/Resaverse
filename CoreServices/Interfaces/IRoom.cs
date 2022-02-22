using CoreServices.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreServices.Interfaces
{
    public interface IRoom
    {
        Task<RoomDTO> Create(RoomDTO room);

        Task<JSONRes<RoomsDTO>> GetRooms();

        Task<RoomDTO> GetRoom(int id);

        Task<RoomsByFloorDTO> GetRoomsByFloor(int floorID);
        
        Task<RoomDTO> UpdateRoom(int id, RoomDTO Room);

        Task Delete(int id);
    }
}
