using CoreServices.DTOs;
using System.Threading.Tasks;

namespace CoreServices.Interfaces
{
    public interface IRoomType
    {
        Task<RoomTypesDTO> Create(RoomTypesDTO roomType);
        Task Delete(int id);
        Task<RoomTypeDTO> GetRoomsByType(int id);
        Task<JSONRes<RoomTypesDTO>> GetRoomTypes();
        Task<RoomTypesDTO> UpdateRoomType(int id, RoomTypesDTO roomType);

    }
}
