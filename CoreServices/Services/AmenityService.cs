using CoreModels.Data;
using CoreModels.Models;
using CoreServices.DTOs;
using CoreServices.Interfaces;
using Microsoft.EntityFrameworkCore;
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
        //**************************************************************************** Create
        public async Task<AmenityDTO> Create(AmenityDTO amenity)
        {
            var amenityInstance = new Amenity
            {
                AmenityName = amenity.AmenityName
            };
            _dbContext.Entry(amenityInstance).State = EntityState.Added;

            await _dbContext.SaveChangesAsync();
            amenity.Id = amenityInstance.Id;

            return amenity;
        }
        //**************************************************************************** GetAmenites
        public async Task<JSONRes<AmenitiesDTO>> GetAmenites()
        {
            var list = await _dbContext.Amenities.Select(e => new AmenitiesDTO
            {
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
        //**************************************************************************** GetAmenity
        public async Task<AmenityDTO> GetAmenity(int id)
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
        //**************************************************************************** UpdateAmenity
        public async Task<AmenityDTO> UpdateAmenity(int id, AmenityDTO amenity)
        {
            var updatedAmenityInstance = new Amenity
            {
                Id = id,
                AmenityName = amenity.AmenityName
            };
            _dbContext.Entry(updatedAmenityInstance).State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();

            return amenity;
        }
        //**************************************************************************** Delete
        public async Task Delete(int id)
        {
            var deletedAmenity = await _dbContext.Amenities.FindAsync(id);
            _dbContext.Entry(deletedAmenity).State = EntityState.Deleted;

            await _dbContext.SaveChangesAsync();

        }
    }
}
