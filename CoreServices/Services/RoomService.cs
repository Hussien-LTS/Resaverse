using CoreServices.DTOs;
using CoreServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreServices.Services
{
    public class RoomService : IRoom
    {
        public RoomDTO Create(RoomDTO Room)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public RoomDTO GetRoom(int id)
        {
            throw new NotImplementedException();
        }

        public List<RoomsDTO> GetRooms()
        {
            throw new NotImplementedException();
        }

        public RoomsByFloorDTO GetRoomsByFloor(int floorID)
        {
            throw new NotImplementedException();
        }

        public RoomDTO UpdateRoom(int id, RoomDTO Room)
        {
            throw new NotImplementedException();
        }
    }
}
