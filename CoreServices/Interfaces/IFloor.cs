using CoreServices.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreServices.Interfaces
{
    public interface IFloor
    {
        Task<JSONRes<FloorsDTO>> GetFloors();
        Task<FloorDTO> GetFloor(int id);
        Task<FloorDTO> Create(FloorDTO floor);
        Task<FloorDTO> UpdateFloorAsync(int id, FloorDTO floor);
        Task Delete(int id);
    }
}
