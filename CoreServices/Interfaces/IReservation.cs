using CoreServices.DTOs;
using System;
using System.Threading.Tasks;

namespace CoreServices.Interfaces
{
    public interface IReservation
    {
        Task<ReservationDTO> Create(ReservationDTO reservationm, int roomId, string userId);

        Task Delete(int roomId, DateTime startTime);
        Task<JSONRes<ReservationsDTO>> GetReservations();

        Task<ReservationDTO> GetReservation(int roomId, DateTime startTime);

        Task<JSONRes<ReservationsByUserDTO>> GetReservationsForUser(string userId);
       
        Task<ReservationDTO> UpdateReservation(int roomId, string userId, DateTime startTime, ReservationDTO reservation);

    }
}
