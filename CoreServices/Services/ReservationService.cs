using CoreModels.Data;
using CoreModels.Models;
using CoreServices.DTOs;
using CoreServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CoreServices.Services
{
    public class ReservationService : IReservation
    {
        private readonly ResaverseDbContext _dbContext;
        public ReservationService(ResaverseDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        //********************************************************************************************************************************** Create
        public async Task<ReservationDTO> Create(ReservationDTO reservation, int roomId, string userId)
        {
            //var userInfo = await _dbContext.Users
            //   .Where(a => a.Id == userId)
            //   .Select(e => new UserDTO
            //   {
            //       Id = e.Id,
            //       Avatar = e.Avatar,
            //       Email = e.Email,
            //       FirstName = e.FirstName,
            //       LastName = e.LastName,
            //       UserName = e.UserName,
            //       PhoneNumber = e.PhoneNumber,
            //   }).FirstOrDefaultAsync();
            var reservationInstance = new Reservation
            {
                Reason = reservation.Reason,
                ReservationStartDate = reservation.ReservationStartDate,
                ReservationEndDate = reservation.ReservationEndDate,
                ReservationStatus = reservation.ReservationStatus,
                UserId = userId,
                RoomId = roomId
            };
            _dbContext.Entry(reservationInstance).State = EntityState.Added;
            await _dbContext.SaveChangesAsync();
            return reservation;
        }
        //********************************************************************************************************************************** GetReservations
        public async Task<JSONRes<ReservationsDTO>> GetReservations()
        {
            var reservations = await _dbContext.Reservations
                .Select(e => new ReservationsDTO
                {
                    Reason = e.Reason,
                    ReservationStartDate = e.ReservationStartDate,
                    ReservationEndDate = e.ReservationEndDate,
                    ReservationStatus = e.ReservationStatus,
                    User = new UserDTO
                    {
                        Id = e.User.Id,
                        Avatar = e.User.Avatar,
                        Email = e.User.Email,
                        FirstName = e.User.FirstName,
                        LastName = e.User.LastName,
                        PhoneNumber = e.User.PhoneNumber,
                        UserName = e.User.Email
                    },
                }).ToListAsync();

            var result = new JSONRes<ReservationsDTO>
            {
                Count = reservations.Count(),
                Results = reservations,
            };
            return result;
        }
        //********************************************************************************************************************************** GetReservation
        public Task<ReservationDTO> GetReservation(int roomId, DateTime startTime)
        {
            var reservation = _dbContext.Reservations
                .Where(e => e.RoomId == roomId && e.ReservationStartDate == startTime)
                .Select(e => new ReservationDTO
                {
                    Reason = e.Reason,
                    ReservationStartDate = e.ReservationStartDate,
                    ReservationEndDate = e.ReservationEndDate,
                    ReservationStatus = e.ReservationStatus,
                    Room = new AminitiesRoomsDTO
                    {
                        RoomID = e.RoomId,
                        RoomCode = e.Room.RoomCode,
                        FloorId = e.Room.FloorId,
                        FloorCode = e.Room.Floor.FloorCode,
                        Availability = e.Room.Availability,
                    },
                    User = new UserDTO
                    {
                        Avatar = e.User.Avatar,
                        Email = e.User.Email,
                        FirstName = e.User.FirstName,
                        Id = e.User.Id,
                        LastName = e.User.LastName,
                        PhoneNumber = e.User.PhoneNumber,
                        UserName = e.User.Email,
                    }
                }).FirstOrDefaultAsync();
            return reservation;
        }
        //********************************************************************************************************************************** GetReservationsForUser
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
        //********************************************************************************************************************************** UpdateReservation
        public async Task<ReservationDTO> UpdateReservation(int roomId, string userId, DateTime startTime, ReservationDTO reservation)
        {
            var updatedReservationInstance = new Reservation
            {
                RoomId = roomId,
                UserId = userId,
                Reason = reservation.Reason,
                ReservationStartDate = reservation.ReservationStartDate,
                ReservationEndDate = reservation.ReservationEndDate,
                ReservationStatus = reservation.ReservationStatus,

            };
            _dbContext.Entry(updatedReservationInstance).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return reservation;
        }
        //********************************************************************************************************************************** Delete
        public async Task Delete(int roomId, DateTime startTime)
        {
            var reservation = await _dbContext.Reservations.Where(a => a.RoomId == roomId && a.ReservationStartDate == startTime).FirstOrDefaultAsync();
            _dbContext.Entry(reservation).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }
    }
}
