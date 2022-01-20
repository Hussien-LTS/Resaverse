using AutoMapper;
using CoreModels.Data;
using CoreServices.DTOs;
using CoreServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreServices.Services
{
    public class RoomService : IRoom
    {
        private readonly ResaverseDbContext _dbContext;
        private readonly IMapper _mapper;

        public RoomService(ResaverseDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<RoomDTO> Create(RoomDTO room)
        {
            _dbContext.Entry(room).State = EntityState.Added;
            await _dbContext.SaveChangesAsync();
            return room;
        }

        public async Task Delete(int id)
        {
            var deletedRoom = await _dbContext.Rooms
                                               .FindAsync(id);
            _dbContext.Entry(deletedRoom).State = EntityState.Deleted;

        }

        public async Task<RoomDTO> GetRoom(int id)
        {
            var room = await _dbContext.Rooms
                                        .Include(f => f.Floor)
                                        .Include(rt => rt.RoomType)
                                        .Include(ra => ra.RoomAmenities).ThenInclude(a => a.Amenity)
                                        .Include(r => r.Reservations)
                                        .FirstOrDefaultAsync(r => r.Id == id);
            var result = _mapper.Map<RoomDTO>(room);

            return result;

        }

        public async Task<List<RoomsDTO>> GetRooms()
        {

            var rooms = await _dbContext.Rooms.Select(a => new RoomsDTO
            {
                Id = a.Id,
                Availability = a.Availability,
                Canvas = a.Canvas,
                Capacity = a.Capacity,
                Coordonation = a.Coordonation,
                RoomCode = a.RoomCode,
                Amenities = a.RoomAmenities.Select(a => new AmenitiesDTO
                {
                    Id = a.AmenityId,
                    AmenityName = a.Amenity.AmenityName
                }).ToList(),
                RoomType = new RoomTypesDTO
                {
                    Id = a.RoomType.Id,
                    Type = a.RoomType.Type
                }
            }).ToListAsync();
            //var rooms = await _dbContext.Rooms
            //                            .Include(rt => rt.RoomType)
            //                            .Include(ra => ra.RoomAmenities).ThenInclude(a => a.Amenity)
            //                            .ToListAsync();
            //var results = _mapper.Map<RoomsDTO>(rooms);
            return rooms;


        }

        public async Task<RoomsByFloorDTO> GetRoomsByFloor(int floorID)
        {
            var rooms = await _dbContext.Rooms
                        .Where(a => a.FloorId == floorID)
                        .Select(a => new RoomsDTO
                        {
                            Id = a.Id,
                            Availability = a.Availability,
                            Canvas = a.Canvas,
                            Capacity = a.Capacity,
                            Coordonation = a.Coordonation,
                            RoomCode = a.RoomCode,
                            Amenities = a.RoomAmenities.Select(a => new AmenitiesDTO
                            {
                                Id = a.AmenityId,
                                AmenityName = a.Amenity.AmenityName
                            }).ToList(),
                            RoomType = new RoomTypesDTO
                            {
                                Id = a.RoomType.Id,
                                Type = a.RoomType.Type
                            }
                        }).ToListAsync();

            var floorCode = await _dbContext.Floors
                .Where(a => a.Id == floorID)
                .FirstOrDefaultAsync();

            var roomsByFloor = new RoomsByFloorDTO
            {
                FloorID = floorID,
                Count = rooms.Count(),
                FloorCode = floorCode.FloorCode,
                Result =rooms
            };
            //var rooms = await _dbContext.Rooms
            //                            .Include(rt => rt.RoomType)
            //                            .Include(ra => ra.RoomAmenities).ThenInclude(a => a.Amenity)
            //                            .ToListAsync();
            //var results = _mapper.Map<RoomsDTO>(rooms);
            return roomsByFloor;
        }

        public async Task<RoomDTO> UpdateRoom(int id, RoomDTO Room)
        {
            _dbContext.Entry(Room).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return Room;
        }
    }
}
