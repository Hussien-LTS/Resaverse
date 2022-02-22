using CoreServices.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreServices.Interfaces
{
    public interface IFloor
    {
        Task<FloorDTO> Create(FloorDTO floor);
        Task<JSONRes<FloorsDTO>> GetFloors();
        Task<FloorDTO> GetFloor(int id);
        Task<FloorDTO> UpdateFloor(int id, FloorDTO floor);
        Task Delete(int id);
    }
}
