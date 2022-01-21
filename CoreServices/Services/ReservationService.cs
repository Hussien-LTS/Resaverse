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
    public class ReservationService : IReservation
    {
        private readonly ResaverseDbContext _dbContext;
        private readonly IMapper _mapper;

        public ReservationService(ResaverseDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ReservationDTO> Create(ReservationDTO reservation)
        {
            _dbContext.Entry(reservation).State = EntityState.Added;
            await _dbContext.SaveChangesAsync();
            return reservation;
        }

        public async Task Delete(int roomId, DateTime startTime)
        {
            var reservation = _dbContext.Reservations
                .Where(e => e.RoomId == roomId && e.ReservationStartDate == startTime);
            _dbContext.Entry(reservation).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }

        public ReservationDTO GetReservation(int roomId, DateTime startTime)
        {
            var reservation = _dbContext.Reservations
                .Where(e => e.RoomId == roomId && e.ReservationStartDate == startTime)
                .Include(e => e.User)
                .Include(e => e.Room);
            var result = _mapper.Map<ReservationDTO>(reservation);
            return result;
        }

        public async Task<JSONRes<ReservationsDTO>> GetReservations()
        {
            var reservations = await _dbContext.Reservations
                .Select(e => new ReservationsDTO {
                    Reason = e.Reason,
                    ReservationStartDate = e.ReservationStartDate,
                    ReservationEndDate = e.ReservationEndDate,
                    ReservationStatus = e.ReservationStatus,
                    User = new UserDTO {
                        Id = e.User.Id,
                        Avatar = e.User.Avatar,
                        Email = e.User.Email,
                        FirstName = e.User.FirstName,
                        LastName = e.User.LastName,
                        UserName = e.User.UserName,
                        PhoneNumber = e.User.PhoneNumber,
                    },
                }).ToListAsync();

            var result = new JSONRes<ReservationsDTO>
            {
                Count = reservations.Count(),
                Results = reservations,
            };

            return result;
        }

        public async Task<JSONRes<ReservationsByUserDTO>> GetReservationsForUser(string userId)
        {
            var reservations = await _dbContext.Reservations
                .Where(e => e.UserId == userId)
                .Select(e => new ReservationsByUserDTO
                {
                    Reason = e.Reason,
                    ReservationStartDate = e.ReservationStartDate,
                    ReservationEndDate = e.ReservationEndDate,
                    ReservationStatus = e.ReservationStatus,
                }).ToListAsync();

            var result = new JSONRes<ReservationsByUserDTO>
            {
                Count = reservations.Count(),
                Results = reservations,
            };

            return result;
        }

        public async Task<ReservationDTO> UpdateReservation(int roomId, DateTime startTime, ReservationDTO reservation)
        {
            //var _reservation = await _dbContext.Reservations
            //    .Where(e => e.RoomId == roomId && e.ReservationStartDate == startTime)
            //    .FirstOrDefaultAsync();
            
            _dbContext.Entry(reservation).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return reservation;

        }
    }
}
