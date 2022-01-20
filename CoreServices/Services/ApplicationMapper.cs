using AutoMapper;
using CoreModels.Models;
using CoreServices.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreServices.Services
{
    public class ApplicationMapper :Profile
    {
        public ApplicationMapper()
        {
            CreateMap<Floor, FloorDTO>().ReverseMap();
            CreateMap<Floor, FloorsDTO>().ReverseMap();
            CreateMap<Room, RoomDTO>().ReverseMap();
            CreateMap<Room, RoomsDTO>().ReverseMap();

        }
    }
}
