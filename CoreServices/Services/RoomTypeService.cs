using AutoMapper;
using CoreModels.Data;
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
        private readonly IMapper _mapper;

        public RoomTypeService(ResaverseDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

        }
        public async Task<RoomTypesDTO> Create(RoomTypesDTO roomType)
        {
            _dbContext.Entry(roomType).State = EntityState.Added;
            await _dbContext.SaveChangesAsync();
            return roomType;

        }

        public async Task Delete(int id)
        {
            var deleted = await _dbContext.RoomTypes.FindAsync(id);
            _dbContext.Entry(deleted).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<RoomTypeDTO> GetRoomsByType(int id)
        {
            var roomTypes = await _dbContext.RoomTypes
                .Include(e => e.Rooms)
                .FirstOrDefaultAsync(e => e.Id == id);
            var result = _mapper.Map<RoomTypeDTO>(roomTypes);
            return result;
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
            _dbContext.Entry(roomType).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return roomType;
        }
    }
}
