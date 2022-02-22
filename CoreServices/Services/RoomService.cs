using CoreModels.Data;
using CoreModels.Models;
using CoreServices.DTOs;
using CoreServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CoreServices.Services
{
    public class RoomService : IRoom
    {
        private readonly ResaverseDbContext _dbContext;

        public RoomService(ResaverseDbContext dbContext)
        {
            _dbContext = dbContext;
        }
       
        public async Task<RoomDTO> Create(RoomDTO room)
        {
            var roomInstance = new Room
            {  
                
                Canvas = room.Canvas,
                Availability = room.Availability,
                Capacity = room.Capacity,
                Coordonation = room.Coordonation,
                RoomCode = room.RoomCode
            };
            _dbContext.Entry(roomInstance).State = EntityState.Added;
            await _dbContext.SaveChangesAsync();
            room.Id = roomInstance.Id;
            return room;
        }

        public async Task<JSONRes<RoomsDTO>> GetRooms()
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
            var results = new JSONRes<RoomsDTO>
            {
                Count = rooms.Count(),
                Results = rooms
            };
            return results;


        }

        public async Task<RoomDTO> GetRoom(int id)
        {
            var room = await _dbContext.Rooms
                .Where(r => r.Id == id)
                .Select(a => new RoomDTO
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
                    },
                    Floor = new FloorsDTO
                    {
                        Id = a.Floor.Id,
                        FloorCode = a.Floor.FloorCode,
                    },
                    Reservations = a.Reservations.Select(e => new ReservationsDTO
                    {
                        Reason = e.Reason,
                        ReservationEndDate = e.ReservationEndDate,
                        ReservationStartDate = e.ReservationStartDate,
                        ReservationStatus = e.ReservationStatus,
                        User = new UserDTO
                        {
                            Avatar = e.User.Avatar,
                            Email = e.User.Email,
                            FirstName = e.User.FirstName,
                            Id = e.User.Id,
                            LastName = e.User.LastName,
                            PhoneNumber = e.User.PhoneNumber,
                            UserName = e.User.UserName,
                        }
                    }).ToList()
                }).FirstOrDefaultAsync();

            return room;

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
                Result = rooms
            };
            //var rooms = await _dbContext.Rooms
            //                            .Include(rt => rt.RoomType)
            //                            .Include(ra => ra.RoomAmenities).ThenInclude(a => a.Amenity)
            //                            .ToListAsync();
            //var results = _mapper.Map<RoomsDTO>(rooms);
            return roomsByFloor;
        }

        public async Task<RoomDTO> UpdateRoom(int id, RoomDTO room)
        {
            var updatedRoomInstance = new Room
            {
                Id = id,
                Canvas = room.Canvas,
                Availability = room.Availability,
                Capacity = room.Capacity,
                Coordonation = room.Coordonation,
                RoomCode = room.RoomCode
            };
            _dbContext.Entry(updatedRoomInstance).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return room;
        }
       
        public async Task Delete(int id)
        {
            var deletedRoom = await _dbContext.Rooms.FindAsync(id);
            _dbContext.Entry(deletedRoom).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();

        }

    }
}
