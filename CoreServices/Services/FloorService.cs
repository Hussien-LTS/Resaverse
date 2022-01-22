using AutoMapper;
using CoreModels.Data;
using CoreModels.Models;
using CoreServices.DTOs;
using CoreServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreServices.Services
{

    public class FloorService : IFloor
    {
        private readonly ResaverseDbContext _dbContext;

        public FloorService(ResaverseDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<FloorDTO> Create(FloorDTO floor)
        {
            _dbContext.Entry(floor).State = EntityState.Added;

            await _dbContext.SaveChangesAsync();

            return floor;
        }

        public async Task Delete(int id)
        {
            Floor deletedFloor = await _dbContext.Floors
                                                 .FindAsync(id);
            _dbContext.Entry(deletedFloor).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<FloorDTO> GetFloor(int id)
        {
            var floor = await _dbContext.Floors
                .Where(e => e.Id == id)
                .Select(f => new FloorDTO
            {
                Id = f.Id,
                Canvas = f.Canvas,
                Coordination = f.Coordination,
                FloorCode = f.FloorCode,
                Rooms = f.Rooms
                    .Select(r => new FloorsRoomsDTO
                {
                    Id = r.Id,
                    Availability = r.Availability,
                    Canvas = r.Canvas,
                    Coordonation = r.Coordonation

                }).ToList()
            }).FirstOrDefaultAsync();


            return floor;
        }

        public async Task<JSONRes<FloorsDTO>> GetFloors()
        {
            var floors = await _dbContext.Floors
                .Select(a => new FloorsDTO
                {
                    Id = a.Id,
                    FloorCode = a.FloorCode
                }).ToListAsync();
            var results = new JSONRes<FloorsDTO>
            {
                Count = floors.Count(),
                Results = floors
            };

            return results;
        }

        public async Task<FloorDTO> UpdateFloorAsync(int id, FloorDTO floor)
        {
            _dbContext.Entry(floor).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return floor;
        }
    }
}
