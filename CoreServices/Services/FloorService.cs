using CoreServices.DTOs;
using CoreServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreServices.Services
{
    public class FloorService : IFloor
    {
        public FloorDTO Create(FloorDTO floor)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public FloorDTO GetFloor(int id)
        {
            throw new NotImplementedException();
        }

        public List<FloorsDTO> GetFloors()
        {
            throw new NotImplementedException();
        }

        public FloorDTO UpdateFloor(int id, FloorDTO floor)
        {
            throw new NotImplementedException();
        }
    }
}
