using CoreServices.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreServices.Interfaces
{
    public interface IFloor
    {
        List<FloorsDTO> GetFloors();
        FloorDTO GetFloor(int id);
        FloorDTO Create(FloorDTO floor);
        FloorDTO UpdateFloor(int id, FloorDTO floor);
        Task Delete(int id);
    }
}
