using CoreServices.DTOs;
using System;
using System.Threading.Tasks;

namespace CoreServices.Interfaces
{
    public interface IReservation
    {
        Task<ReservationDTO> Create(ReservationDTO reservation);
        Task Delete(int roomId, DateTime startTime);
        Task<ReservationDTO> GetReservation(int roomId, DateTime startTime);
        Task<JSONRes<ReservationsDTO>> GetReservations();
        Task<JSONRes<ReservationsByUserDTO>> GetReservationsForUser(string userId);
        Task<ReservationDTO> UpdateReservation(int roomId, DateTime startTime, ReservationDTO reservation);

    }
}
