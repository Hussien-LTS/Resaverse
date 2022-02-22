using AutoMapper;
using CoreModels.Data;
using CoreModels.Models;
using CoreServices.DTOs;
using CoreServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreServices.Services
{
    public class RoomTypeService : IRoomType
    {
        private readonly ResaverseDbContext _dbContext;

        public RoomTypeService(ResaverseDbContext dbContext)
        {
            _dbContext = dbContext;

        }
       
        public async Task<RoomTypesDTO> Create(RoomTypesDTO roomType)
        {
            var roomTypesInstance = new RoomType
            {
                Type = roomType.Type
            };
            _dbContext.Entry(roomTypesInstance).State = EntityState.Added;
            await _dbContext.SaveChangesAsync();
            roomType.Id = roomTypesInstance.Id;
            return roomType;

        }

        public async Task<RoomTypeDTO> GetRoomsByType(int id)
        {
            var roomTypes = await _dbContext.RoomTypes
                .Where(e => e.Id == id)
                .Select(e => new RoomTypeDTO {
                    Id = e.Id,
                    Type = e.Type,
                    Rooms = e.Rooms.Select(e => new AminitiesRoomsDTO
                    {
                        RoomID = e.Id,
                        FloorId = e.FloorId,
                        FloorCode = e.Floor.FloorCode,
                        RoomCode = e.RoomCode,
                        Availability = e.Availability,
                    }).ToList()
                })
                .FirstOrDefaultAsync();
            

            return roomTypes;
        }

        public async Task<JSONRes<RoomTypesDTO>> GetRoomTypes()
        {
            var roomTypes = await _dbContext.RoomTypes
                .Select(e => new RoomTypesDTO
                {
                    Id = e.Id,
                    Type = e.Type,
                }).ToListAsync();

            var result = new JSONRes<RoomTypesDTO>
            {
                Count = roomTypes.Count(),
                Results = roomTypes,
            };

            return result;
        }

        public async Task<RoomTypesDTO> UpdateRoomType(int id, RoomTypesDTO roomType)
        {
            var UpdatedRoomTypesInstance = new RoomType
            {
                Id = id,
                Type = roomType.Type
            };
            _dbContext.Entry(UpdatedRoomTypesInstance).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return roomType;
        }

        public async Task Delete(int id)
        {
            var deleted = await _dbContext.RoomTypes.FindAsync(id);
            _dbContext.Entry(deleted).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }
    }
}
