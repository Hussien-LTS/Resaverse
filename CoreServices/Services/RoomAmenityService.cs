using CoreModels.Data;
using CoreServices.DTOs;
using CoreServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CoreServices.Services
{
    public class RoomAmenityService : IRoomAmenity
    {
        private readonly ResaverseDbContext _dbContext;
        public RoomAmenityService(ResaverseDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //********************************************************************************* AddAmenity
        public async Task<RoomAmenityDTO> AddAmenity(int roomId, int amenityId)
        {
            var roomAmenity = new RoomAmenityDTO()
            {
                RoomId = roomId,
                AmenityId = amenityId
            };
            _dbContext.Entry(roomAmenity).State = EntityState.Added;
            await _dbContext.SaveChangesAsync();
            await _dbContext.RoomAmenities
                .Include(x => x.Room)
                .FirstOrDefaultAsync(x => x.RoomId == roomId);
            await _dbContext.RoomAmenities
                .Include(x => x.Amenity)
                .FirstOrDefaultAsync(x => x.AmenityId == amenityId);
            return roomAmenity;
        }
        //********************************************************************************* RemoveAmenity
        public async Task RemoveAmenity(int roomId, int amenityId)
        {
            var roomAmenity = await _dbContext.RoomAmenities
                                              .FirstOrDefaultAsync(x => (x.RoomId == roomId) && (x.AmenityId == amenityId));
            _dbContext.Entry(roomAmenity).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }
    }
}
