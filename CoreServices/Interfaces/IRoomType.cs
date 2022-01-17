using CoreServices.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreServices.Interfaces
{
    public interface IRoomType
    {
        List<RoomTypesDTO> GetRoomTypes();
        RoomTypeDTO GetRoomsByType(int id);
        RoomTypesDTO Create(RoomTypesDTO RoomType);
        RoomTypesDTO UpdateRoomType(int id, RoomTypesDTO RoomType);
        Task Delete(int id);

    }
}
