using AutoMapper;
using CoreModels.Data;
using CoreModels.Models;
using CoreServices.DTOs;
using CoreServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreServices.Services
{

    public class FloorService : IFloor
    {
        private readonly ResaverseDbContext _dbContext;
        private readonly IMapper _mapper;

        public FloorService(ResaverseDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
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
            //var floor = await _dbContext.Floors.Select(f => new FloorDTO
            //{
            //    Id = f.Id,
            //    Canvas = f.Canvas,
            //    Coordination = f.Coordination,
            //    FloorCode = f.FloorCode,
            //    Rooms = f.Rooms.Select(r=> new FloorsRoomsDTO
            //    {
            //        Id = r.Id,
            //        Availability = r.Availability,
            //        Canvas = r.Canvas,
            //        Coordonation = r.Coordonation

            //    }).ToList()
            //}).FirstOrDefaultAsync(s => s.Id == id);
            Floor floor = await _dbContext.Floors
                                          .Include(r => r.Rooms)
                                          .FirstOrDefaultAsync(f => f.Id == id);
            var result = _mapper.Map<FloorDTO>(floor);

            return result;
        }

        public async Task<List<FloorsDTO>> GetFloors()
        {
            var Floors = await _dbContext.Floors
                                          .Include(r => r.Rooms)
                                          .ToListAsync();
            var results = _mapper.Map<List<FloorsDTO>>(Floors);

            return results;
            //throw new NotImplementedException();
        }

        public async Task<FloorDTO> UpdateFloorAsync(int id, FloorDTO floor)
        {
            _dbContext.Entry(floor).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return floor;
        }
    }
}
