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
    public class AmenityService : IAmenity
    {
        private readonly ResaverseDbContext _dbContext;

        public AmenityService(ResaverseDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        public async Task<AmenityDTO> Create(AmenityDTO amenity)
        {
            _dbContext.Entry(amenity).State = EntityState.Added;

            await _dbContext.SaveChangesAsync();

            return amenity;
        }

        public async Task Delete(int id)
        {
            var deletedAmenity = await _dbContext.Amenities.FindAsync(id);
            _dbContext.Entry(deletedAmenity).State = EntityState.Deleted;

            await _dbContext.SaveChangesAsync();

        }

        public async Task<JSONRes<AmenitiesDTO>> GetAmenites()
        {
            var list = await _dbContext.Amenities.Select(e => new AmenitiesDTO {
                Id = e.Id,
                AmenityName = e.AmenityName,
            }).ToListAsync();

            var ameniteis = new JSONRes<AmenitiesDTO>
            {
                Count = list.Count(),
                Results = list,
            };
            return ameniteis;
        }

        public async Task<AmenityDTO> GetAmenityDTO(int id)
        {
            var amenity = await _dbContext.Amenities
                .Where(e => e.Id == id)
                .Select(e => new AmenityDTO
                {
                    Id = e.Id,
                    AmenityName = e.AmenityName,
                    Rooms = e.RoomAmenities
                        .Select(e => new AminitiesRoomsDTO
                        {
                            RoomID = e.Room.Id,
                            FloorId = e.Room.FloorId,
                            FloorCode = e.Room.Floor.FloorCode,
                            RoomCode = e.Room.RoomCode,
                            Availability = e.Room.Availability,
                        }).ToList()
                }).FirstOrDefaultAsync();

            return amenity;
        }

        public async Task<AmenityDTO> UpdateAmenityDTO(int id, AmenityDTO amenity)
        {
            _dbContext.Entry(amenity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return amenity;
        }
    }
}
