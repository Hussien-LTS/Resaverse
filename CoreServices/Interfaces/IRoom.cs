using CoreServices.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreServices.Interfaces
{
    public interface IRoom
    {
        List<RoomsDTO> GetRooms();
        RoomDTO GetRoom(int id);
        RoomsByFloorDTO GetRoomsByFloor(int floorID);
        RoomDTO Create(RoomDTO Room);
        RoomDTO UpdateRoom(int id, RoomDTO Room);
        Task Delete(int id);
    }
}
